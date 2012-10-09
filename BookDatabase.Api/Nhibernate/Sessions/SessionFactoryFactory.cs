//-----------------------------------------------------------------------
// <copyright file="SessionFactoryFactory.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using BookDatabase.Api.Nhibernate.Conventions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BookDatabase.Api.Nhibernate.Sessions
{
    /// <summary>
    /// Abstract class from which SessionFactoryFactory instances should inherit
    /// </summary>
    public abstract class SessionFactoryFactory : ISessionFactoryFactory
    {
        #region Private Static Readonly Fields

        /// <summary>
        /// Stores a lock to allow thread-safe access to the sessionFactory
        /// </summary>
        private static readonly object SessionFactoryLock = new object();

        #endregion

        #region Private Static Fields

        /// <summary>
        /// Stores the sessionFactory instance to use
        /// </summary>
        private static ISessionFactory sessionFactory;

        #endregion

        #region Protected Abstract Properties

        /// <summary>
        /// Gets the database configuration to use
        /// </summary>
        protected abstract IPersistenceConfigurer DatabaseConfiguration { get; }

        /// <summary>
        /// Gets the assembly to use for mappings
        /// </summary>
        protected abstract Assembly MappingsAssembly { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a SessionFactory
        /// </summary>
        /// <returns>A configured SessionFactory</returns>
        public ISessionFactory GetInstance()
        {
            lock (SessionFactoryLock)
            {
                if (sessionFactory == null)
                {
                    sessionFactory = Fluently.Configure()
                        .Database(DatabaseConfiguration)
                        .Mappings(x => x.FluentMappings.AddFromAssembly(MappingsAssembly))
                        .Mappings(x => x.HbmMappings.AddFromAssembly(MappingsAssembly))
                        .Mappings(x => x.FluentMappings.Conventions.Add(new CustomForeignKeyConvention()))
                        .BuildSessionFactory();
                }

                return sessionFactory;
            }
        }

        #endregion
    }
}
