//-----------------------------------------------------------------------
// <copyright file="UnitOfWorkTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using BookDatabase.Api.Tests.BusinessObjects.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;

namespace BookDatabase.Api.Tests.Data.Transactions
{
    /// <summary>
    /// Tests for UnitOfWork
    /// </summary>
    [TestClass]
    public class UnitOfWorkTests
    {
        #region Public Methods - Tests

        /// <summary>
        /// Tests calling commit without adding any operations
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCommitWithNoOperations()
        {
            // Arrange:
            var sessionMock = new Mock<ISession>();
            var target = UnitOfWorkHelper.Get(sessionMock);

            // Act:
            target.Commit();

            // Assert:
        }

        /// <summary>
        /// Tests calling rollback without adding any operations
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRollbackWithNoOperations()
        {
            // Arrange:
            var sessionMock = new Mock<ISession>();
            var target = UnitOfWorkHelper.Get(sessionMock);

            // Act:
            target.Rollback();

            // Assert:
        }

        /// <summary>
        /// Tests saving and commiting
        /// </summary>
        [TestMethod]
        public void TestSaveAndCommit()
        {
            // Arrange:
            var transactionMock = new Mock<ITransaction>();
            
            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);

            var target = UnitOfWorkHelper.Get(sessionMock);

            var user = UserHelper.GetNewValidUser();

            // Act:
            target.SaveOrUpdate(user);
            target.Commit();

            // Assert:
            sessionMock.Verify(x => x.BeginTransaction(), Times.Once());
            sessionMock.Verify(x => x.SaveOrUpdate(user), Times.Once());
            transactionMock.Verify(x => x.Commit(), Times.Once());
        }

        /// <summary>
        /// Tests saving and rolling back
        /// </summary>
        [TestMethod]
        public void TestSaveAndRollback()
        {
            // Arrange:
            var transactionMock = new Mock<ITransaction>();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);
            
            var target = UnitOfWorkHelper.Get(sessionMock);

            var user = UserHelper.GetNewValidUser();

            // Act:
            target.SaveOrUpdate(user);
            target.Rollback();

            // Assert:
            sessionMock.Verify(x => x.BeginTransaction(), Times.Once());
            sessionMock.Verify(x => x.SaveOrUpdate(user), Times.Once());
            transactionMock.Verify(x => x.Rollback(), Times.Once());
        }

        /// <summary>
        /// Tests deleting and commiting
        /// </summary>
        [TestMethod]
        public void TestDeleteAndCommit()
        {
            // Arrange:
            var transactionMock = new Mock<ITransaction>();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);
            
            var target = UnitOfWorkHelper.Get(sessionMock);

            var user = UserHelper.GetNewValidUser();

            // Act:
            target.Delete(user);
            target.Commit();

            // Assert:
            sessionMock.Verify(x => x.BeginTransaction(), Times.Once());
            sessionMock.Verify(x => x.Delete(user), Times.Once());
            transactionMock.Verify(x => x.Commit(), Times.Once());
        }

        /// <summary>
        /// Tests deleting and rolling back
        /// </summary>
        [TestMethod]
        public void TestDeleteAndRollback()
        {
            // Arrange:
            var transactionMock = new Mock<ITransaction>();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);
            
            var target = UnitOfWorkHelper.Get(sessionMock);

            var user = UserHelper.GetNewValidUser();

            // Act:
            target.Delete(user);
            target.Rollback();

            // Assert:
            sessionMock.Verify(x => x.BeginTransaction(), Times.Once());
            sessionMock.Verify(x => x.Delete(user), Times.Once());
            transactionMock.Verify(x => x.Rollback(), Times.Once());
        }

        /// <summary>
        /// Tests performing multiple operations under a single transaction
        /// </summary>
        [TestMethod]
        public void TestCommitMultipleOperations()
        {
            // Arrange:
            var transactionMock = new Mock<ITransaction>();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);
            
            var target = UnitOfWorkHelper.Get(sessionMock);

            var user1 = UserHelper.GetNewValidUser();
            var user2 = UserHelper.GetNewValidUser();

            // Act:
            target.SaveOrUpdate(user1);
            target.SaveOrUpdate(user2);
            target.Commit();

            // Assert:
            sessionMock.Verify(x => x.BeginTransaction(), Times.Once());
            sessionMock.Verify(x => x.SaveOrUpdate(user1), Times.Once());
            sessionMock.Verify(x => x.SaveOrUpdate(user2), Times.Once());
            transactionMock.Verify(x => x.Commit(), Times.Once());
        }

        /// <summary>
        /// Tests performing operations under multiple transactions
        /// </summary>
        [TestMethod]
        public void TestCommitMultipleTransactions()
        {
            // Arrange:
            var transactionMock = new Mock<ITransaction>();

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(x => x.BeginTransaction()).Returns(transactionMock.Object);
            
            var target = UnitOfWorkHelper.Get(sessionMock);

            var user1 = UserHelper.GetNewValidUser();
            var user2 = UserHelper.GetNewValidUser();

            // Act:
            target.SaveOrUpdate(user1);
            target.SaveOrUpdate(user2);
            target.Commit();
            target.Delete(user1);
            target.Delete(user2);
            target.Commit();

            // Assert:
            sessionMock.Verify(x => x.BeginTransaction(), Times.Exactly(2));
            sessionMock.Verify(x => x.SaveOrUpdate(user1), Times.Once());
            sessionMock.Verify(x => x.SaveOrUpdate(user2), Times.Once());
            sessionMock.Verify(x => x.Delete(user1), Times.Once());
            sessionMock.Verify(x => x.Delete(user2), Times.Once());
            transactionMock.Verify(x => x.Commit(), Times.Exactly(2));
        }

        #endregion
    }
}