//-----------------------------------------------------------------------
// <copyright file="IAdministratorRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Data.Repositories.Users
{
    /// <summary>
    /// Interface for administrator repositories
    /// </summary>
    public interface IAdministratorRepository : IUserBaseRepository<Administrator>
    {
        // No implementation
    }
}
