using PPECB_Technical_Assessment.HelperMethods;
using PPECB_Technical_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace PPECB_Technical_Assessment.Controllers
{
    public class ValuesController : ApiController
    {
        private TechTestDBEntities dbcontext = new TechTestDBEntities();
        // GET api/values
        public IEnumerable<Employee> Get()
        {
            return dbcontext.Employees.ToList();
        }
        // GET api/values/5
        [HttpPost]
        public Employee Get(int id)
        {
            return dbcontext.Employees.Where(S=>S.id==id).FirstOrDefault();
        }
        // POST api/values
       
        [HttpPost]
        public void Post(Employee e)
        {
            dbcontext.Employees.Add(e);
            dbcontext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, Employee e)
        {
            try
            {
                Employee GetEmployee = dbcontext.Employees.Where(s => s.id == id).FirstOrDefault();
                GetEmployee.age = e.age;
                GetEmployee.firstName = e.firstName;
                GetEmployee.gender = e.gender;
                GetEmployee.lastName = e.lastName;
                dbcontext.Entry(GetEmployee).State = EntityState.Modified;
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                Employee GetEmployee = dbcontext.Employees.Find(id);
                dbcontext.Entry(GetEmployee).State = EntityState.Deleted;
                dbcontext.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
