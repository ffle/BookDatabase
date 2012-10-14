//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Data.Repositories.Users
{
    /// <summary>
    /// Repository to store users
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Public Methods

        /// <summary>
        /// Gets a user by user name and passwoed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        /// <returns>A matching user, or null</returns>
        public User Get(string userName, string password)
        {
            var users = Session.QueryOver<User>().Where(x => x.UserName == userName && x.Password == password).List();
            return users.FirstOrDefault();
        }

        #endregion
    }
}
