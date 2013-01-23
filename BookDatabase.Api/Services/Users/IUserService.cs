//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Services.Users
{
    /// <summary>
    /// Interface for the User service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by user name and passwoed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        /// <returns>A matching user, or null</returns>
        User Get(string userName, string password);

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="user">The user to register</param>
        void Register(User user);
    }
}
