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
    public interface IUserRepository : IUserBaseRepository<User>
    {
        // No implementation
    }
}
