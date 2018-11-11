using PPECB_Technical_Assessment.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace PPECB_Technical_Assessment.HelperMethods
{
    public interface IApiControllerService
    {
        string EditEmployeeDetails([FromBody]Employee employee);
        string AddEmployeeDetails(Employee employee);
        string DeleteEmployee(Employee employee);
    }

    // TODO: Amanda Inject in Unity
    public class ApiControllerService :IApiControllerService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IApiHelperService _apiHelperService;
        public ApiControllerService
            (IHttpClientService httpClientService, IApiHelperService apiHelperService)
        {
            _httpClientService = httpClientService;
            _apiHelperService = apiHelperService;
        }

        public string AddEmployeeDetails(Employee employee)
        {
            Task<HttpResponseMessage> ResponseFromTask = _httpClientService.HttpClient().PostAsJsonAsync(_apiHelperService.GetCreateEmpoyeeUrl(), employee);
            ResponseFromTask.Wait();
            HttpResponseMessage result = ResponseFromTask.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<Employee> readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();

                return HelperReturnMessages.BootstrapAlertSuccess("New Employee Added successfully!");
            }
            return HelperReturnMessages.BootstrapAlertFailed("System failure, try again later.");
        }

        public string DeleteEmployee(Employee employee)
        {
            Task<HttpResponseMessage> ResponseFromTask = _httpClientService.HttpClient().DeleteAsync(_apiHelperService.GetDeleteEmpoyeeUrl(employee.id));
            ResponseFromTask.Wait();
            HttpResponseMessage result = ResponseFromTask.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<Employee> readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();

                return HelperReturnMessages.BootstrapAlertSuccess("Employee Deleted successfully!");
            }
            return HelperReturnMessages.BootstrapAlertFailed("System failure, try again later.");
        }

        public string EditEmployeeDetails([FromBody] Employee employee)
        {
            Task<HttpResponseMessage> ResponseFromTask = _httpClientService.HttpClient().PutAsJsonAsync(_apiHelperService.GetEditEmpoyeeUrl(employee.id), employee);
            ResponseFromTask.Wait();
            HttpResponseMessage result = ResponseFromTask.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<Employee> readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();

                return HelperReturnMessages.BootstrapAlertSuccess("Employee details updated successfully!");
            }
            return HelperReturnMessages.BootstrapAlertFailed("Update failed, try again later.");
        }

    }
}
