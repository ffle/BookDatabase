//-----------------------------------------------------------------------
// <copyright file="ConfigurationFile.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace BookDatabase.Api.Tests.Configuration
{
    /// <summary>
    /// Test configuration file
    /// </summary>
    public class ConfigurationFile : Api.Configuration.ConfigurationFile
    {
        #region Public Properties

        /// <summary>
        /// Gets the connection string for the master database
        /// </summary>
        public string MasterConnectionString
        {
            get
            {
                return GetString(Environment.MachineName + ":MasterConnectionString");
            }
        }

        /// <summary>
        /// Gets the connection string for the BookDatabase database
        /// </summary>
        public string BookDatabaseConnectionString
        {
            get
            {
                return this.GetString(Environment.MachineName + ":BookDatabaseConnectionString");
            }
        }

        #endregion
    }
}
