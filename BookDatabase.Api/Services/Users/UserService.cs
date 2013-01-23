//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;
using BookDatabase.Api.Data.Repositories.Users;

namespace BookDatabase.Api.Services.Users
{
    /// <summary>
    /// Service for Users
    /// </summary>
    public class UserService : IUserService, IService
    {
        /// <summary>
        /// Gets or sets the user repository
        /// </summary>
        public IUserRepository UserRepository { get; set; }

        /// <summary>
        /// Gets a user by user name and passwoed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        /// <returns>A matching user, or null</returns>
        public User Get(string userName, string password)
        {
            return UserRepository.Get(userName, password);
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="user">The user to register</param>
        public void Register(User user)
        {
            // Done!
        }
    }
}
