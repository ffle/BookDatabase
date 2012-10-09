﻿//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.BusinessObjects;

namespace BookDatabase.Api.Data.Repositories
{
    /// <summary>
    /// Interface which all repositories must implement
    /// </summary>
    /// <typeparam name="T">The type of business object the repository is associated with</typeparam>
    public interface IRepository<out T> : IDisposable
        where T : BusinessObject
    {
        #region Methods

        /// <summary>
        /// Gets an object by Id
        /// </summary>
        /// <param name="id">The Id of the object to retrieve</param>
        /// <returns>The object matching the Id, or null</returns>
        T GetById(int id);

        #endregion
    }
}