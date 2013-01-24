//-----------------------------------------------------------------------
// <copyright file="Injector.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using BookDatabase.Api.BusinessObjects.Users;
using BookDatabase.Api.Data.Transactions;
using BookDatabase.Web.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using log4net;

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

            RegisterInjector(container);
            RegisterConfiguration(container);
            RegisterLogging(container);
            RegisterControllers(container);
            RegisterServices(container);
            RegisterDataComponents(container);
            
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

            // Note that the following statement only works if "If" is used for 
            // both conditions:
            container.Register(
                    AllTypes.FromThisAssembly()
                    .BasedOn(typeof(IController))
                    .If(t => t.Name.EndsWith("Controller"))
                    .If(t => t.Namespace.StartsWith("BookDatabase.Web.Controllers"))
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
        /// Registers repositories and the unit of work type
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterDataComponents(WindsorContainer container)
        {
            container.Register(AllTypes.FromAssemblyContaining(typeof(User))
                .Where(type => type.Name.EndsWith("Repository"))
                .If(type => type.Namespace.StartsWith("BookDatabase.Api.Data.Repositories"))
                .WithService.DefaultInterface()
                .Configure(c => c.LifeStyle.PerWebRequest));

            container.Register(
                Component.For<IUnitOfWork>()
                .ImplementedBy(typeof(UnitOfWork))
                .LifeStyle.PerWebRequest);
        }

        /// <summary>
        /// Registers services
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterServices(WindsorContainer container)
        {
            container.Register(AllTypes.FromAssemblyContaining(typeof(User))
                .Where(type => type.Name.EndsWith("Service"))
                .If(type => type.Namespace.StartsWith("BookDatabase.Api.Services"))
                .WithService.DefaultInterface()
                .Configure(c => c.LifeStyle.Singleton));
        }

        /// <summary>
        /// Registers the dependency injector
        /// </summary>
        /// <param name="container">The container</param>
        private static void RegisterInjector(WindsorContainer container)
        {
            container.Register(
                Component.For<IWindsorContainer>()
                .Instance(container));
        }
    }
}