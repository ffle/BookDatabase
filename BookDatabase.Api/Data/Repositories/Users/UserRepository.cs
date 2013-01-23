//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Data.Repositories.Users
{
    /// <summary>
    /// Repository to store users
    /// </summary>
    public class UserRepository : UserBaseRepository<User>, IUserRepository
    {
        // No implementation
    }
}
