//-----------------------------------------------------------------------
// <copyright file="AdministratorRepositoryTests.cs" company="Steve Barker">
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
    /// Test for AdministratorRepository
    /// </summary>
    [TestClass]
    public class AdministratorRepositoryTests
    {
        /// <summary>
        /// Tests the Get method
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            // Arrange:
            var administrator = AdministratorHelper.GetNewValidAdministrator();

            var queryOverMock = new QueryOverMock<Administrator>(new List<Administrator> { administrator });

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.QueryOver<Administrator>()).Returns(queryOverMock);

            var target = RepositoryHelper.Get<AdministratorRepository, Administrator>(sessionMock);

            // Act:
            var actualAdministrator = target.Get(administrator.UserName, administrator.Password);

            // Assert:
            Assert.AreEqual(administrator, actualAdministrator);
        }
    }
}
