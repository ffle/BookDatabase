//-----------------------------------------------------------------------
// <copyright file="SessionContainer.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.Configuration;
using BookDatabase.Api.Nhibernate.Sessions;
using Castle.Core.Logging;
using NHibernate;

namespace BookDatabase.Api.Data
{
    /// <summary>
    /// Class from which all classes using containers (e.g. repositories and transaction) inherit
    /// </summary>
    public abstract class SessionContainer : IDisposable
    {
        #region Private Readonly Fields

        /// <summary>
        /// Lock to ensure thread-safe access to the session
        /// </summary>
        private readonly object sessionLock = new object();

        #endregion

        #region Private Fields

        /// <summary>
        /// Stores the active session
        /// </summary>
        private ISession session;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the SessionFactoryFactory
        /// </summary>
        public ISessionFactoryFactory SessionFactoryFactory { get; set; }

        /// <summary>
        /// Gets or sets the logger
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets configuration required by the API
        /// </summary>
        public IApiConfigurationFile ConfigurationFile { get; set; }

        #endregion

        #region Protected Virtual Properties

        /// <summary>
        /// Gets the session in use by the instance
        /// </summary>
        protected virtual ISession Session
        {
            get
            {
                lock (sessionLock)
                {
                    return session ?? (session = SessionFactoryFactory.GetInstance().OpenSession());
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Disposes of the repository
        /// </summary>
        public void Dispose()
        {
#warning Implement this using MS guidelines
            DisposeSession();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes an operation, retrying if an exception is encountered
        /// </summary>
        /// <typeparam name="TReturn">The type of the operation return value</typeparam>
        /// <param name="operation">The operation</param>
        /// <returns>The return value of the operation</returns>
        protected TReturn ExecuteOperationWithRetry<TReturn>(Func<TReturn> operation)
        {
            var retries = 0;
            var maximumRetries = ConfigurationFile.DatabaseOperationRetries;
            var currentException = new Exception("Retry code not working correctly");

            while (retries < maximumRetries)
            {
                try
                {
                    return operation.Invoke();
                }
                catch (Exception exception)
                {
                    // Get a reference to the exception that will survive outside
                    // of the while loop:
                    currentException = exception;

                    // The exception is transient, perform a retry. Note that we need to re-create
                    // the session as an NHibernate session becomes unusable following an exception:
                    DisposeSession();
                    retries++;
                }
            }

            // If we get here, the retry code didn't work, so throw the exception:
            throw currentException;
        }
        
        /// <summary>
        /// Executes an operation, retrying if an exception is encountered
        /// </summary>
        /// <param name="operation">The operation</param>
        protected void ExecuteOperationWithRetry(Action operation)
        {
            // We turn the Action into an Func so that it can be executed as a Func: 
            Func<bool> newOperation = () =>
            {
                operation.Invoke();
                return true;
            };

            // We call the other execute method and discard the return value:
            ExecuteOperationWithRetry(newOperation);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Safely disposes the session and sets it to null
        /// </summary>
        private void DisposeSession()
        {
            try
            {
                session.Close();
                session.Dispose();
            }
            catch
            {
                // Ignore exceptions
            }

            // Setting the session to null will ensure that it is re-created if
            // needed again:
            session = null;
        }

        #endregion
    }
}
