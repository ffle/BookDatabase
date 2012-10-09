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
                return this.GetValue<string>(Environment.MachineName + ":MasterConnectionString");
            }
        }

        /// <summary>
        /// Gets the connection string for the BookDatabase database
        /// </summary>
        public string BookDatabaseConnectionString
        {
            get
            {
                return this.GetValue<string>(Environment.MachineName + ":BookDatabaseConnectionString");
            }
        }

        #endregion
    }
}
