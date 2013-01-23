//-----------------------------------------------------------------------
// <copyright file="ConfigurationFile.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;

namespace BookDatabase.Api.Configuration
{
    /// <summary>
    /// Class from which all configuration file abstractions inherit
    /// </summary>
    public abstract class ConfigurationFile
    {
        /// <summary>
        /// The reader used to interact with the configuration file
        /// </summary>
        private readonly AppSettingsReader reader = new AppSettingsReader();

        /// <summary>
        /// Gets a string value from the configuration file
        /// </summary>
        /// <param name="key">The name of the value</param>
        /// <returns>The configuration string value</returns>
        protected string GetString(string key)
        {
            return (string)reader.GetValue(key, typeof(string));
        }

        /// <summary>
        /// Gets an int from the configuration file
        /// </summary>
        /// <param name="key">The name of the key the int is stored in</param>
        /// <returns>The corresponding int value</returns>
        protected int GetInt(string key)
        {
            var text = GetString(key);
            return int.Parse(text);
        }
    }
}
