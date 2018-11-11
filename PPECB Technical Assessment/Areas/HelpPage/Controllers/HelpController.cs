using PPECB_Technical_Assessment.Areas.HelpPage.ModelDescriptions;
using PPECB_Technical_Assessment.Areas.HelpPage.Models;
using System.Web.Http;
using System.Web.Mvc;

namespace PPECB_Technical_Assessment.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        //public HelpController()
        //    : this(System.Web.Http.GlobalConfiguration.Configuration)
        //{
        //}
       // public readonly HttpConfiguration Configuration;
       
        public HelpController(/*HttpConfiguration Config*/)
        {
           // Configuration = new HttpConfiguration();
        }
        protected static HttpConfiguration Configuration
        {
            get { return GlobalConfiguration.Configuration; }
        }


        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!string.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out ModelDescription modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}