using Microsoft.Practices.Unity.Configuration;
//using PPECB_Technical_Assessment.Areas.HelpPage;
//using PPECB_Technical_Assessment.Areas.HelpPage.ModelDescriptions;
using PPECB_Technical_Assessment.HelperMethods;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using Unity;
using Unity.AspNet.Mvc;

namespace PPECB_Technical_Assessment
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
           // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IHttpClientService, GetHttpClientService>();
            container.RegisterType<IApiHelperService, GetAPIHelperUrls>();
            container.RegisterType<IApiControllerService, ApiControllerService>();
           
        }
    }
}