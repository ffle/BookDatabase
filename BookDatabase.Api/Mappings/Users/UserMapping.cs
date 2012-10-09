//-----------------------------------------------------------------------
// <copyright file="UserMapping.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;

namespace BookDatabase.Api.Mappings.Users
{
    /// <summary>
    /// Mappings for User
    /// </summary>
    public class UserMapping : BusinessObjectClassMap<User>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the UserMapping class
        /// </summary>
        public UserMapping()
        {
            Map(x => x.UserName).Length(100).Not.Nullable().Unique();
            Map(x => x.FirstName).Length(100).Not.Nullable();
            Map(x => x.LastName).Length(100).Not.Nullable();
        }

        #endregion
    }
}
