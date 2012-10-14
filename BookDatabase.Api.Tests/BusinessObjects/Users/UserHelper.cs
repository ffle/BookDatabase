//-----------------------------------------------------------------------
// <copyright file="UserHelper.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

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
        public static User ValidUser1
        {
            get
            {
                return new User
                {
                    UserName = "UserName1",
                    Password = "Password",
                    FirstName = "FirstName",
                    LastName = "LastName",
                };
            }
        }

        #endregion
    }
}
