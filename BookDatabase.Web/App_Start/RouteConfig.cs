//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Routing;

namespace BookDatabase.Web.App_Start
{
    /// <summary>
    /// The RouteConfig class
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers routes
        /// </summary>
        /// <param name="routes">The routes collection</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}