//-----------------------------------------------------------------------
// <copyright file="UserRepositoryTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookDatabase.Api.Data.Repositories.Users;
using BookDatabase.Api.BusinessObjects.Users;
using Moq;
using NHibernate;
using BookDatabase.Api.Tests.BusinessObjects.Users;

namespace BookDatabase.Api.Tests.Data.Repositories.Users
{
    /// <summary>
    /// Test for UserRepository
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {
        #region Public Methods - Tests
        
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange:
            var user = UserHelper.GetNewValidUser();

            var IQueryOVer
            var sessionMock = new Mock<ISession>();
            // sessionMock.
            var target = RepositoryHelper.Get<UserRepository, User>(sessionMock);

            // Act:
            var actualUser = target.Get(user.UserName, user.Password);

            // Assert:
            Assert.AreEqual(user, actualUser);
        }

        #endregion
    }
}
