//-----------------------------------------------------------------------
// <copyright file="ConfigurationFile.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Mail;

namespace BookDatabase.Api.Configuration
{
    /// <summary>
    /// Class from which all configuration file abstractions inherit
    /// </summary>
    public abstract class ConfigurationFile
    {
        #region Private Fields

        /// <summary>
        /// The reader used to interact with the configuration file
        /// </summary>
        private readonly AppSettingsReader reader = new AppSettingsReader();

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets a built-in typed value from the configuration file
        /// </summary>
        /// <typeparam name="T">The type of the value to get</typeparam>
        /// <param name="key">The name of the value</param>
        /// <returns>The configuration value</returns>
        protected T GetValue<T>(string key)
        {
            try
            {
                return (T)reader.GetValue(key, typeof(T));
            }
            catch (Exception e)
            {
                string m = string.Format(CultureInfo.CurrentCulture, "An error occurred while reading key {0}: {1}", key, e.Message);
                throw new ConfigurationErrorsException(m);
            }
        }

        /// <summary>
        /// Gets a directory from the configuration file
        /// </summary>
        /// <param name="key">The name of the key the directory path is stored in</param>
        /// <returns>A configured DirectoryInfo object</returns>
        protected DirectoryInfo GetDirectoryInfo(string key)
        {
            var path = GetValue<string>(key);
            return new DirectoryInfo(path);
        }

        /// <summary>
        /// Gets a file from the configuration file
        /// </summary>
        /// <param name="key">The name of the key the file path is stored in</param>
        /// <returns>A configured FileInfo object</returns>
        protected FileInfo GetFileInfo(string key)
        {
            var path = GetValue<string>(key);
            return new FileInfo(path);
        }

        /// <summary>
        /// Gets a URI from the configuration file
        /// </summary>
        /// <param name="key">The name of the key the URI is stored in</param>
        /// <returns>A configured URI object</returns>
        protected Uri GetUri(string key)
        {
            var uri = GetValue<string>(key);
            return new Uri(uri);
        }

        /// <summary>
        /// Gets an email address from the configuration file
        /// </summary>
        /// <param name="key">The name of the key the address is stored in</param>
        /// <returns>A configured EmailAddress object</returns>
        protected MailAddress GetEmailAddress(string key)
        {
            var address = GetValue<string>(key);
            return new MailAddress(address);
        }

        #endregion
    }
}
