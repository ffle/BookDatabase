//-----------------------------------------------------------------------
// <copyright file="RepositoryTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using BookDatabase.Api.BusinessObjects;
using BookDatabase.Api.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;

namespace BookDatabase.Api.Tests.Data.Repositories
{
    /// <summary>
    /// Tests for repository
    /// </summary>
    [TestClass]
    public class RepositoryTests
    {
        #region Public Methods - Tests

        /// <summary>
        /// Tests the GetAll methods
        /// </summary>
        [TestMethod]
        public void GetAllTest()
        {
            // Arrange:
            var items = GetTestData();

            var criteriaMock = new Mock<ICriteria>();
            criteriaMock.Setup(x => x.List<TestBusinessObject>()).Returns(items);

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.CreateCriteria<TestBusinessObject>()).Returns(criteriaMock.Object);

            var target = RepositoryHelper.Get<TestRepository, TestBusinessObject>(sessionMock);
            
            // Act:
            var result = target.GetAll();
            
            // Assert:
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(items, result);
        }

        /// <summary>
        /// Tests the GetAll methods
        /// </summary>
        [TestMethod]
        public void GetByIdTest()
        {
            // Arrange:
            var items = GetTestData();
            var expectedItem = items.FirstOrDefault();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.Get<TestBusinessObject>(expectedItem.Id)).Returns(expectedItem);

            var target = RepositoryHelper.Get<TestRepository, TestBusinessObject>(sessionMock);

            // Act:
            var result = target.GetById(expectedItem.Id.Value);

            // Assert:
            Assert.AreEqual(expectedItem, result);
        }

        #endregion 

        #region Private Static Methods

        /// <summary>
        /// Gets test data
        /// </summary>
        /// <returns>Test data</returns>
        private static IList<TestBusinessObject> GetTestData()
        {
            return new List<TestBusinessObject>
            {
                new TestBusinessObject { Id = 1, Name = "Item1" },
                new TestBusinessObject { Id = 2, Name = "Item2" },
            };
        }

        #endregion

        #region Private Classes

        /// <summary>
        /// Test repository
        /// </summary>
        private class TestRepository : Repository<TestBusinessObject>
        {
            // No implementation
        }

        /// <summary>
        /// Test business object
        /// </summary>
        private class TestBusinessObject : BusinessObject
        {
            #region Public Properties

            /// <summary>
            /// Gets or sets the name
            /// </summary>
            public string Name { get; set; }

            #endregion
        }
        
        #endregion
    }
}
