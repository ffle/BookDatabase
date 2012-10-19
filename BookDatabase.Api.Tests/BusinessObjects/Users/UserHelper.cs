//-----------------------------------------------------------------------
// <copyright file="UserHelper.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Tests.BusinessObjects.Users
{
    /// <summary>
    /// Helper for User
    /// </summary>
    public static class UserHelper
    {
        #region Public Static Properties

        /// <summary>
        /// Gets a valid user
        /// </summary>
        /// <param name="userName">The user name to use, or null to assign a random Guid</param>
        /// <returns>A new user item</returns>
        public static User GetNewValidUser(string userName = null)
        {
            // Convert null user names to random Guids:
            userName = string.IsNullOrEmpty(userName) ? Guid.NewGuid().ToString() : userName;

            return new User
            {
                UserName = userName,
                Password = "Password",
                FirstName = "FirstName",
                LastName = "LastName",
            };
        }

        #endregion
    }
}
