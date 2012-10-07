//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookDatabase.Web
{
    /// <summary>
    /// The RouteConfig class
    /// </summary>
    public class RouteConfig
    {
        #region Public Static Methods

        /// <summary>
        /// Registers routes
        /// </summary>
        /// <param name="routes">The routes collection</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        #endregion
    }
}