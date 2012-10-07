//-----------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web;
using System.Web.Mvc;

namespace BookDatabase.Web
{
    /// <summary>
    /// The FilterConfig class
    /// </summary>
    public class FilterConfig
    {
        #region Public Static Methods

        /// <summary>
        /// Registers global filters
        /// </summary>
        /// <param name="filters">The filters collection</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}