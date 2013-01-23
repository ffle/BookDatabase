//-----------------------------------------------------------------------
// <copyright file="AdministratorRepository.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Data.Repositories.Users
{
    /// <summary>
    /// Repository to store administrators
    /// </summary>
    public class AdministratorRepository : UserBaseRepository<Administrator>, IAdministratorRepository
    {
        // No implementation
    }
}
