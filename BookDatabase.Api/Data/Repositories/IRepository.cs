//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using BookDatabase.Api.BusinessObjects;

namespace BookDatabase.Api.Data.Repositories
{
    /// <summary>
    /// Interface which all repositories must implement
    /// </summary>
    /// <typeparam name="T">The type of business object the repository is associated with</typeparam>
    public interface IRepository<out T> : IDisposable, IRepository
        where T : BusinessObject
    {
        /// <summary>
        /// Gets an object by Id
        /// </summary>
        /// <param name="id">The Id of the object to retrieve</param>
        /// <returns>The object matching the Id, or null</returns>
        T GetById(int id);

        /// <summary>
        /// Gets all items in the repository
        /// </summary>
        /// <returns>All items in the repository</returns>
        IEnumerable<T> GetAll();
    }

    /// <summary>
    /// Interface which identifies all repositories as such
    /// </summary>
    public interface IRepository
    {
        // No implementation
    }
}
