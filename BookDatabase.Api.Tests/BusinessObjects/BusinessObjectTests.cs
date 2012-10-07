//-----------------------------------------------------------------------
// <copyright file="BusinessObjectTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookDatabase.Api.Tests.BusinessObjects
{
    /// <summary>
    /// Tests of BusinessObject
    /// </summary>
    [TestClass]
    public class BusinessObjectTests
    {
        #region Public Methods - Tests

        /// <summary>
        /// Tests IsNew
        /// </summary>
        [TestMethod]
        public void IsNewTest()
        {
            // Arrange:
            var target1 = new TestBusinessObject { Name = "Name" };
            var target2 = new TestBusinessObject { Id = 1, Name = "Name" };

            // Act:
            var target1IsNew = target1.IsNew;
            var target2IsNew = target2.IsNew;

            // Assert:
            Assert.IsTrue(target1IsNew); 
            Assert.IsFalse(target2IsNew);            
        }

        /// <summary>
        /// Tests the == operator
        /// </summary>
        [TestMethod]
        public void EqualsOperatorTest()
        {
            // Arrange:
            var targetNew1 = new TestBusinessObject { Name = "A" };
            var targetNew2 = new TestBusinessObject { Name = "B" };            

            // Act:
            var nullAndNull = (TestBusinessObject)null == (TestBusinessObject)null;
            var nullAndNotNull = targetNew1 == (TestBusinessObject)null;
            var notNullAndNull = (TestBusinessObject)null == targetNew1;

            // Assert:
            Assert.IsTrue(nullAndNull);
            throw new NotImplementedException("Need to do more here");
        }

        #endregion

        #region Private Classes

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
