//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using BookDatabase.Api.Services.Users;
using BookDatabase.Web.ViewModels.User;

namespace BookDatabase.Web.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Gets or sets the user service
        /// </summary>
        public IUserService UserService { get; set; }

        /// <summary>
        /// Register GET action
        /// </summary>
        /// <returns>The action result</returns>
        public ActionResult Register()
        {
            return View("Register");
        }

        /// <summary>
        /// Register POST action
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns>The action result</returns>
        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            UserService.Register(null);
            return View("Register");
        }
    }
}
