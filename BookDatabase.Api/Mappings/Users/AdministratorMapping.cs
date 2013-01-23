//-----------------------------------------------------------------------
// <copyright file="AdministratorMapping.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Mappings.Users
{
    /// <summary>
    /// Mappings for Administrator
    /// </summary>
    public class AdministratorMapping : BusinessObjectClassMap<Administrator>
    {
        /// <summary>
        /// Initializes a new instance of the AdministratorMapping class
        /// </summary>
        public AdministratorMapping()
        {
            Map(x => x.UserName).Length(100).Not.Nullable().Unique();
            Map(x => x.Password).Length(100).Not.Nullable();
            Map(x => x.FirstName).Length(100).Not.Nullable();
            Map(x => x.LastName).Length(100).Not.Nullable();
        }
    }
}
