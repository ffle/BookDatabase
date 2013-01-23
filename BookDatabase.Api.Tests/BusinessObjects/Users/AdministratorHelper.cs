//-----------------------------------------------------------------------
// <copyright file="AdministratorHelper.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Tests.BusinessObjects.Users
{
    /// <summary>
    /// Helper for Administrator
    /// </summary>
    public static class AdministratorHelper
    {
        /// <summary>
        /// Gets a valid administrator
        /// </summary>
        /// <param name="userName">The user name to use, or null to assign a random Guid</param>
        /// <returns>A new user item</returns>
        public static Administrator GetNewValidAdministrator(string userName = null)
        {
            // Convert null user names to random Guids:
            userName = string.IsNullOrEmpty(userName) ? Guid.NewGuid().ToString() : userName;

            return new Administrator
            {
                UserName = userName,
                Password = "Password",
                FirstName = "FirstName",
                LastName = "LastName",
            };
        }
    }
}
