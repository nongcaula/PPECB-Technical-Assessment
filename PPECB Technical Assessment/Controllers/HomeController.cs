using Newtonsoft.Json;
using PPECB_Technical_Assessment.HelperMethods;
using PPECB_Technical_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace PPECB_Technical_Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IApiHelperService _apiHelperService;
        private readonly IApiControllerService _apiControllerService;
        public HomeController
            (IHttpClientService httpClientService,
            IApiHelperService apiHelperService,
            IApiControllerService apiControllerService)
        {
            _apiControllerService = apiControllerService ?? throw new ArgumentNullException(nameof(apiControllerService));
            _apiHelperService = apiHelperService ?? throw new ArgumentNullException(nameof(apiHelperService));
            _httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
        }

        public string EditEmployeeDetails([FromBody]Employee employee)
        {
            return _apiControllerService.EditEmployeeDetails(employee);
        }
        public string AddEmployeeDetails(Employee employee)
        {
            return _apiControllerService.AddEmployeeDetails(employee);
        }
        public string DeleteEmployee(Employee employee)
        {
            return _apiControllerService.DeleteEmployee(employee);
        }

        //TODO:Amanda Controller handles incoming URL requests not doing the actual work, need to create a service.
        public async Task<ActionResult> Index()
        {
            List<Employee> Employeenfo = new List<Employee>();
            HttpResponseMessage Res = await _httpClientService.HttpClient().GetAsync(_apiHelperService.GetAllEmpoyeeAPIUrl());
            if (Res.IsSuccessStatusCode)
            {
                string EmpResponse = Res.Content.ReadAsStringAsync().Result;
                Employeenfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
            }
            return View(Employeenfo);
        }
        public async Task<PartialViewResult> GetEmployeeDetails(int id)
        {
            if (id != 0)
            {
                List<Employee> Employeenfo = new List<Employee>();
                HttpResponseMessage results = await _httpClientService.HttpClient().GetAsync(_apiHelperService.GetSingleEmpoyeeUrl(id));
                if (results.IsSuccessStatusCode)
                {
                    string EmpResponse = results.Content.ReadAsStringAsync().Result;
                    Employeenfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
                    Employee SingleEmployee = Employeenfo.Where(s => s.id == id).FirstOrDefault();
                    SingleEmployee.gender = SingleEmployee.gender.Trim();
                    return PartialView(SingleEmployee);
                }
            }
            return PartialView(new Employee());
        }
    }
}
