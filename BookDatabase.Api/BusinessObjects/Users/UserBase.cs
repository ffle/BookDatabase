//-----------------------------------------------------------------------
// <copyright file="UserBase.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

namespace BookDatabase.Api.BusinessObjects.Users
{
    /// <summary>
    /// Base class from which users inherit
    /// </summary>
    public abstract class UserBase : BusinessObject
    {
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }
    }
}
