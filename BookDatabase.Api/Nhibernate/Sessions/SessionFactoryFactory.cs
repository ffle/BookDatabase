//-----------------------------------------------------------------------
// <copyright file="SessionFactoryFactory.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.Configuration;
using BookDatabase.Api.Nhibernate.Conventions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BookDatabase.Api.Nhibernate.Sessions
{
    /// <summary>
    /// Abstract class from which SessionFactoryFactory instances should inherit
    /// </summary>
    public class SessionFactoryFactory : ISessionFactoryFactory
    {
        /// <summary>
        /// Stores a lock to allow thread-safe access to the sessionFactory
        /// </summary>
        private static readonly object SessionFactoryLock = new object();

        /// <summary>
        /// Stores the sessionFactory instance to use
        /// </summary>
        private static ISessionFactory sessionFactory;

        /// <summary>
        /// Gets or sets the configuration file
        /// </summary>
        public IApiConfigurationFile ConfigurationFile { get; set; }

        /// <summary>
        /// Gets a SessionFactory
        /// </summary>
        /// <returns>A configured SessionFactory</returns>
        public virtual ISessionFactory GetInstance()
        {
            lock (SessionFactoryLock)
            {
                if (sessionFactory == null)
                {
                    var mappingsAssembly = GetType().Assembly;
                    
#if DEBUG 
                    var databaseConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationFile.ConnectionString).ShowSql();
#else
                    var databaseConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationFile.ConnectionString);
#endif

                    sessionFactory = Fluently.Configure()
                        .Database(databaseConfiguration)
                        .Mappings(x => x.FluentMappings.AddFromAssembly(mappingsAssembly))
                        .Mappings(x => x.HbmMappings.AddFromAssembly(mappingsAssembly))
                        .Mappings(x => x.FluentMappings.Conventions.Add(new CustomForeignKeyConvention()))
                        .BuildSessionFactory();
                }

                return sessionFactory;
            }
        }
    }
}
