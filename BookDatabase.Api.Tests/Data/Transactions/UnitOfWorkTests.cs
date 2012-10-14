using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookDatabase.Api.Data.Transactions;

namespace BookDatabase.Api.Tests.Data.Transactions
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCommitWithNoOperations()
        {
            // Arrange:
            var target = new UnitOfWork();

            // Act:
            target.Commit();

            // Assert:
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRollbackWithNoOperations()
        {
            // Arrange:
            var target = new UnitOfWork();

            // Act:
            target.Rollback();

            // Assert:
        }

        [TestMethod]
        public void TestSaveAndCommit()
        {
            // Arrange:
            var target = new UnitOfWork
            {
#error FInish this
            };

            // Act:
            target.SaveOrUpdate(

            // Assert:
        }

        [TestMethod]
        public void TestDeleteAndCommit()
        {
            // Arrange:
            var target = new UnitOfWork
            {
#error FInish this                
            };

            // Act:
            target.SaveOrUpdate(

            // Assert:
        }
    }
}

/*
*/