//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Data.Repositories.Users
{
    /// <summary>
    /// Interface for user repositories
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        #region Methods

        /// <summary>
        /// Gets a user by user name and passwoed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        /// <returns>A matching user, or null</returns>
        User Get(string userName, string password);

        #endregion
    }
}
