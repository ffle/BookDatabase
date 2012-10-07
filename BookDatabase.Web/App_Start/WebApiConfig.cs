//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookDatabase.Web
{
    /// <summary>
    /// The WebApiConfig class
    /// </summary>
    public static class WebApiConfig
    {
        #region Public Static Methods
        
        /// <summary>
        /// Registers configuration
        /// </summary>
        /// <param name="config">The configuration to register</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        #endregion
    }
}
