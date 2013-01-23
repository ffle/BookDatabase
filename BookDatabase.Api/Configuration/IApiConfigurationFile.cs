//-----------------------------------------------------------------------
// <copyright file="IApiConfigurationFile.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

namespace BookDatabase.Api.Configuration
{
    /// <summary>
    /// Interface for configuration required by the Api
    /// </summary>
    public interface IApiConfigurationFile
    {
        /// <summary>
        /// Gets the connection string
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Gets the number of database retries
        /// </summary>
        int DatabaseOperationRetries { get; }
    }
}
