//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using BookDatabase.Web.App_Start;
using BookDatabase.Web.DependencyInjection;
using log4net;

namespace BookDatabase.Web
{
    /// <summary>
    /// Application class
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Fires when the application starts
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var log = Injector.Instance.Resolve<ILog>();
            log.Info("Application Started");
        }

        /// <summary>
        /// Fires when the application ends
        /// </summary>
        protected void Application_End()
        {
            Injector.Instance.Dispose();
        }
    }
}