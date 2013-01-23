//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Http;

namespace BookDatabase.Web.App_Start
{
    /// <summary>
    /// The WebApiConfig class
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers configuration
        /// </summary>
        /// <param name="config">The configuration to register</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}
