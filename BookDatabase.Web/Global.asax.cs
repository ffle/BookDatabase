//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookDatabase.Web
{
    /// <summary>
    /// Application class
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Protected Methods

        /// <summary>
        /// Fires when the application starts
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        #endregion
    }
}