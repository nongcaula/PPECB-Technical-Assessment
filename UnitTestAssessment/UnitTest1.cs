using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPECB_Technical_Assessment.Controllers;
using PPECB_Technical_Assessment.HelperMethods;
using PPECB_Technical_Assessment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UnitTestAssessment
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new ValuesController();
            var result = controller.Get();
            using (TechTestDBEntities dbcontext = new TechTestDBEntities())
            {
                var actual = dbcontext.Employees.ToList();
                Assert.IsTrue(result.Any()==actual.Any());
            }
        }
    }
}
