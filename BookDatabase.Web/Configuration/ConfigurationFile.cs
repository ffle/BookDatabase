//-----------------------------------------------------------------------
// <copyright file="ConfigurationFile.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

namespace BookDatabase.Web.Configuration
{
    /// <summary>
    /// Class to encapsulate all interaction with the configuration file
    /// </summary>
    public class ConfigurationFile : Api.Configuration.ConfigurationFile, IWebConfigurationFile
    {
        #region Public Properties

        /// <summary>
        /// Gets the connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return GetString("ConnectionString");
            }
        }

        /// <summary>
        /// Gets the number of database retries
        /// </summary>
        public int DatabaseOperationRetries
        {
            get
            {
                return GetInt("DatabaseOperationRetries");
            }
        }

        #endregion
    }
}