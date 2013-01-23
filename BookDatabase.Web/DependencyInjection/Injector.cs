//-----------------------------------------------------------------------
// <copyright file="Injector.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using BookDatabase.Web.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using log4net;
using BookDatabase.Api.BusinessObjects.Users;
using BookDatabase.Api.Data;
using BookDatabase.Api.Data.Repositories;
using BookDatabase.Api.Services;
using BookDatabase.Api.Services.Users;

namespace BookDatabase.Web.DependencyInjection
{
    /// <summary>
    /// Class that provides dependency injection
    /// </summary>
    public static class Injector
    {
        /// <summary>
        /// Stores an instance of the injector
        /// </summary>
        private static readonly object InstanceLock = new object();

        /// <summary>
        /// Stores the singleton instance
        /// </summary>
        private static IWindsorContainer instance;

        /// <summary>
        /// Gets the singleton instance
        /// </summary>
        public static IWindsorContainer Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    return instance ?? (instance = GetInjector());
                }
            }
        }

        /// <summary>
        /// Gets an injector instance
        /// </summary>
        /// <returns>A configured injector</returns>
        private static IWindsorContainer GetInjector()
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.This());

            RegisterControllers(container);
            RegisterLogging(container);
            RegisterConfiguration(container);
            RegisterRepositories(container);
            RegisterServices(container);

            return container;
        }

        /// <summary>
        /// Registers controllers
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterControllers(WindsorContainer container)
        {
            var controllerFactory = new ControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            container.Register(
                    AllTypes.FromThisAssembly()
                    .BasedOn(typeof(IController))
                    .If(t => t.Name.EndsWith("Controller"))
                    .Configure(c => c.LifeStyle.PerWebRequest));
        }

        /// <summary>
        /// Registers logging
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterLogging(WindsorContainer container)
        {
            container.Register(
                 Component.For<ILog>()
                 .Instance(LogManager.GetLogger(typeof(MvcApplication)))
                 .LifeStyle.Singleton);
        }

        /// <summary>
        /// Registers configuration
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterConfiguration(WindsorContainer container)
        {
            container.Register(
                   Component.For<IWebConfigurationFile>()
                   .ImplementedBy(typeof(ConfigurationFile))
                   .LifeStyle.Singleton);
        }

        /// <summary>
        /// Registers repositories
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterRepositories(WindsorContainer container)
        {
            container.Register(
                    AllTypes.FromAssemblyContaining(typeof(User))
                    .BasedOn(typeof(IRepository))
                    .If(t => t.Name.EndsWith("Repository"))
                    .Configure(c => c.LifeStyle.PerWebRequest));
        }

        /// <summary>
        /// Registers services
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterServices(WindsorContainer container)
        {
#error this doesn't work!!!! Fix and test in application start method
            container.Register(
                    AllTypes.FromAssemblyContaining(typeof(User))
                    .BasedOn(typeof(IService))
                    .Where(t => t.Name.EndsWith("Service"))
                    .Configure(c => c.LifeStyle.PerWebRequest));
        }
    }
}