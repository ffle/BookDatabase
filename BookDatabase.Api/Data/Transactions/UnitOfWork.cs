//-----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects;
using NHibernate;

namespace BookDatabase.Api.Data.Transactions
{
    using System;

    /// <summary>
    /// Interface for the unit of work item
    /// </summary>
    public class UnitOfWork : SessionContainer, IUnitOfWork
    {
        #region Private Readonly Fields

        /// <summary>
        /// Stores a lock to allow thread-safe access to the current transaction
        /// </summary>
        private readonly object currentTransactionLock = new object();

        #endregion

        #region Private Fields

        /// <summary>
        /// Stores the current transaction
        /// </summary>
        private ITransaction currentTransaction;
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Saves an item
        /// </summary>
        /// <param name="item">The item to save</param>
        public void SaveOrUpdate(BusinessObject item)
        {
            lock (currentTransactionLock)
            {
                ConfigureCurrentTransaction();
                ExecuteOperationWithRetry(() => Session.SaveOrUpdate(item));
            }
        }

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="item">The item to delete</param>
        public void Delete(BusinessObject item)
        {
            lock (currentTransactionLock)
            {
                ConfigureCurrentTransaction();
                ExecuteOperationWithRetry(() => Session.Delete(item));
            }
        }

        /// <summary>
        /// Rolls back the current transaction
        /// </summary>
        public void Rollback()
        {
            lock (currentTransactionLock)
            {
                if (currentTransaction == null)
                {
                    throw new InvalidOperationException("No transaction has been started");
                }

                ExecuteOperationWithRetry(() => currentTransaction.Rollback());
                DisposeCurrentTransaction();
            }
        }

        /// <summary>
        /// Commits the current transaction
        /// </summary>
        public void Commit()
        {
            lock (currentTransactionLock)
            {
                if (currentTransaction == null)
                {
                    throw new InvalidOperationException("No transaction has been started");
                }

                ExecuteOperationWithRetry(() => currentTransaction.Commit());
                DisposeCurrentTransaction();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Ensures there is a transaction to use
        /// </summary>
        private void ConfigureCurrentTransaction()
        {
            if (currentTransaction == null)
            {
                ExecuteOperationWithRetry(() => currentTransaction = Session.BeginTransaction());
            }
        }

        /// <summary>
        /// Disposes of the current transaction
        /// </summary>
        private void DisposeCurrentTransaction()
        {
            if (currentTransaction != null)
            {
                try
                {
                    currentTransaction.Dispose();
                }
                catch
                {
                    // Ignore
                }
                finally
                {
                    currentTransaction = null;
                }
            }
        }

        #endregion
    }
}
