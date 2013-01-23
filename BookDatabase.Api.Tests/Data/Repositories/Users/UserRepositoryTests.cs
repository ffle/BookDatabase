//-----------------------------------------------------------------------
// <copyright file="UserRepositoryTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using BookDatabase.Api.BusinessObjects.Users;
using BookDatabase.Api.Data.Repositories.Users;
using BookDatabase.Api.Tests.BusinessObjects.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;

namespace BookDatabase.Api.Tests.Data.Repositories.Users
{
    /// <summary>
    /// Test for UserRepository
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {
        /// <summary>
        /// Tests the Get method
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            // Arrange:
            var user = UserHelper.GetNewValidUser();

            var queryOverMock = new QueryOverMock<User>(new List<User> { user });

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.QueryOver<User>()).Returns(queryOverMock);
            
            var target = RepositoryHelper.Get<UserRepository, User>(sessionMock);

            // Act:
            var actualUser = target.Get(user.UserName, user.Password);

            // Assert:
            Assert.AreEqual(user, actualUser);
        }
    }
}
