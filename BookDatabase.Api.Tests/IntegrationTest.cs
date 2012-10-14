//-----------------------------------------------------------------------
// <copyright file="IntegrationTest.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.BusinessObjects.Users;
using BookDatabase.Api.Nhibernate.Conventions;
using BookDatabase.Api.Tests.Configuration;
using BookDatabase.Api.Tests.DataHelpers;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace BookDatabase.Api.Tests
{
    /// <summary>
    /// Class containing helper methods to aid with integration testing
    /// </summary>
    [TestClass]
    public abstract class IntegrationTest
    {
        #region Private Static Fields

        /// <summary>
        /// Stores a value indicating whether test initialization has been attempted
        /// </summary>
        private static bool testInitializeAttempted;

        /// <summary>
        /// Stores a value indicating whether test initialization has completed
        /// </summary>
        private static bool testInitializeComplete;

        #endregion

        #region Protected Static Properties

        /// <summary>
        /// Gets a session factory
        /// </summary>
        protected static ISessionFactory SessionFactory { get; private set; }

        /// <summary>
        /// Gets a session
        /// </summary>
        protected static ISession Session { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Fires before each integration test is executed
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // If we have already initialized, get a new session and return:
            if (testInitializeComplete)
            {
                Session = SessionFactory.OpenSession();
                return;
            }

            // If we have attempted to run initialization without completing throw an exception:
            if (testInitializeAttempted)
            {
                throw new InvalidOperationException("TestInitialize failed to run");
            }

            testInitializeAttempted = true;

            // Configure Log4Net to watch NHibernate:
            XmlConfigurator.Configure();

            // Configure the database:
            ConfigureDatabase();

            // Create the session:
            Session = SessionFactory.OpenSession();

            testInitializeComplete = true;
        }

        /// <summary>
        /// Closes the session after each test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            Session.Close();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Builds the database 
        /// </summary>
        /// <param name="configuration">The NHibernate configuration</param>
        private static void BuildSchema(NHibernate.Cfg.Configuration configuration)
        {
            new SchemaExport(configuration).Create(false, true);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Updates the 
        /// </summary>
        private static void ConfigureDatabase()
        {
            // Deploy the database if required:
            var sqlExecutor = new MasterSqlExecutor();
            if (!sqlExecutor.DatabaseExists)
            {
                sqlExecutor.DeleteDatabase();
                sqlExecutor.CreateDatabase();
            }

            // Get the connection string:
            var configurationFile = new ConfigurationFile();
            var connectionString = configurationFile.BookDatabaseConnectionString;

            // Run NHibernate and create a session factory:
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
                .ExposeConfiguration(BuildSchema)
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<User>())
                .Mappings(x => x.FluentMappings.Conventions.Add(new CustomForeignKeyConvention()))
                .BuildSessionFactory();
        }

        #endregion
    }
}