//-----------------------------------------------------------------------
// <copyright file="UserMappingTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects.Users;
using BookDatabase.Api.Tests.BusinessObjects.Users;
using FluentNHibernate.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Exceptions;

namespace BookDatabase.Api.Tests.Mappings.Users
{
    /// <summary>
    /// Tests for UserMapping
    /// </summary>
    [TestClass]
    public class UserMappingTests : IntegrationTest
    {
        /// <summary>
        /// Tests mappings
        /// </summary>
        [TestMethod]
        public void MappingsTest()
        {
            new PersistenceSpecification<User>(Session)
                .CheckProperty(x => x.UserName, "UserName")
                .CheckProperty(x => x.Password, "Password")
                .CheckProperty(x => x.FirstName, "FirstName")
                .CheckProperty(x => x.LastName, "LastName")
                .VerifyTheMappings();
        }

        /// <summary>
        /// Tests UserName uniqueness
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GenericADOException))]
        public void UniqueNameTest()
        {
            // Arrange:
            Session.Save(UserHelper.ValidUser1);
            Session.Save(UserHelper.ValidUser1);
        }
    }
}
