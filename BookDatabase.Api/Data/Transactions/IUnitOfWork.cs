//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.BusinessObjects;

namespace BookDatabase.Api.Data.Transactions
{
    /// <summary>
    /// Interface for the unit of work item
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Methods

        /// <summary>
        /// Saves an item
        /// </summary>
        /// <param name="item">The entity to save</param>
        void SaveOrUpdate(BusinessObject item);

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="item">The item to delete</param>
        void Delete(BusinessObject item);

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
