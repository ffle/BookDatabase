//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace BookDatabase.Api.Data.Transactions
{
    /// <summary>
    /// Interface for the unit of work item
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Methods

        /// <summary>
        /// Saves an entity
        /// </summary>
        /// <param name="entity">The entity to save</param>
        void AddOrUpdate(object entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        void Delete(object entity);

        /// <summary>
        /// Starts a transaction
        /// </summary>
        void StartTransaction();

        /// <summary>
        /// Rolls back the current transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Commits the current transaction
        /// </summary>
        void Commit();

        #endregion
    }
}
