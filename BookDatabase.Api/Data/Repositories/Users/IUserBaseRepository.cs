//-----------------------------------------------------------------------
// <copyright file="IUserBaseRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Data.Repositories.Users
{
    /// <summary>
    /// Interface for user repositories
    /// </summary>
    /// <typeparam name="T">The type of user</typeparam>
    public interface IUserBaseRepository<out T> : IRepository<T> where T : UserBase
    {
        /// <summary>
        /// Gets a user by user name and passwoed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        /// <returns>A matching user, or null</returns>
        T Get(string userName, string password);
    }
}
