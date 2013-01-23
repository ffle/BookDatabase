//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using BookDatabase.Api.BusinessObjects;

namespace BookDatabase.Api.Data.Repositories
{
    /// <summary>
    /// Abstract class from which all repositories inherit
    /// </summary>
    /// <typeparam name="T">The type of item handled by the repository</typeparam>
    public abstract class Repository<T> : SessionContainer, IRepository<T> where T : BusinessObject
    {
        /// <summary>
        /// Gets a business object by Id
        /// </summary>
        /// <param name="id">The Id of the object to get</param>
        /// <returns>The object corresponding with the given Id, or null</returns>
        public virtual T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        /// <summary>
        /// Gets all items in the repository
        /// </summary>
        /// <returns>All items in the repository</returns>
        public virtual IEnumerable<T> GetAll()
        {
            var criteria = Session.CreateCriteria<T>();
            return criteria.List<T>();
        }
    }
}
