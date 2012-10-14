//-----------------------------------------------------------------------
// <copyright file="MasterSqlExecutor.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using BookDatabase.Api.Tests.Configuration;

namespace BookDatabase.Api.Tests.DataHelpers
{
    /// <summary>
    /// Class used to execute SQL
    /// </summary>
    public class MasterSqlExecutor : SqlExecutor
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the MasterSqlExecutor class
        /// </summary>
        public MasterSqlExecutor()
            : base(ConnectionString)
        {
            // No implementation
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the database exists
        /// </summary>
        public bool DatabaseExists
        {
            get
            {
                var rowCount = this.ExecuteScalar<int>("SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE [name] = 'BookDatabase'", CommandType.Text);
                return rowCount == 1;
            }
        }

        #endregion

        #region Private Static Properties

        /// <summary>
        /// Gets the connection string
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                var configurationFile = new ConfigurationFile();
                return configurationFile.MasterConnectionString;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the BookDatabase database
        /// </summary>
        public void CreateDatabase()
        {
            this.ExecuteNonQuery("CREATE DATABASE BookDatabase", CommandType.Text);
        }

        /// <summary>
        /// Deletes the BookDatabase database
        /// </summary>
        public void DeleteDatabase()
        {
            this.ExecuteNonQuery("DELETE DATABASE BookDatabase", CommandType.Text);
        }

        #endregion
    }
}
