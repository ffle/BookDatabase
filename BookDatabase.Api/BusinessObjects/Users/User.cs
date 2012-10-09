//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookDatabase.Api.BusinessObjects.Users
{
    /// <summary>
    /// Class to represent a user
    /// </summary>
    public class User : BusinessObject
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        #endregion
    }
}
