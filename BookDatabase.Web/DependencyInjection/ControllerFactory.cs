//-----------------------------------------------------------------------
// <copyright file="ControllerFactory.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace BookDatabase.Web.DependencyInjection
{
    /// <summary>
    /// Controller factory
    /// </summary>
    public class ControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Stores the kernal
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the ControllerFactory class
        /// </summary>
        /// <param name="kernel">The kernal</param>
        public ControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Releases a controller
        /// </summary>
        /// <param name="controller">The controller to release</param>
        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        /// <summary>
        /// Gets a controller instance
        /// </summary>
        /// <param name="requestContext">The request context</param>
        /// <param name="controllerType">The controller type</param>
        /// <returns>Returns an instance of the requested controller</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
               throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)kernel.Resolve(controllerType);
        }
    }
}