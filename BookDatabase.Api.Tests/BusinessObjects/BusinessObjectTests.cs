//-----------------------------------------------------------------------
// <copyright file="BusinessObjectTests.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookDatabase.Api.Tests.BusinessObjects
{
    /// <summary>
    /// Tests of BusinessObject
    /// </summary>
    [TestClass]
    public class BusinessObjectTests
    {
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
        /// Tests the equality operators
        /// </summary>
        [TestMethod]
        public void EqualityOperatorsTest()
        {
            // Arrange:
            var newA = new TestBusinessObject { Name = "A" };
            var newB = new TestBusinessObject { Name = "B" };
            var savedA1 = new TestBusinessObject { Id = 1, Name = "A" };
            var savedA2 = new TestBusinessObject { Id = 2, Name = "A" };
            var savedB = new TestBusinessObject { Id = 3, Name = "B" };

            // Act/Assert:
            EqualityOperatorsTestHelper(null, null, true);
            EqualityOperatorsTestHelper(newA, null, false);
            EqualityOperatorsTestHelper(null, newA, false);
            EqualityOperatorsTestHelper(newA, newA, true);
            EqualityOperatorsTestHelper(newA, newB, false);
            EqualityOperatorsTestHelper(newB, savedB, false);
            EqualityOperatorsTestHelper(savedA1, savedA1, true);
            EqualityOperatorsTestHelper(savedA1, savedA2, false);
            EqualityOperatorsTestHelper(savedA1, savedB, false);
        }

        /// <summary>
        /// Tests the Equals methods
        /// </summary>
        [TestMethod]
        public void EqualsMethodsTest()
        {
            // Arrange:
            var newA = new TestBusinessObject { Name = "A" };
            var newB = new TestBusinessObject { Name = "B" };
            var savedA1 = new TestBusinessObject { Id = 1, Name = "A" };
            var savedA2 = new TestBusinessObject { Id = 2, Name = "A" };
            var savedB = new TestBusinessObject { Id = 3, Name = "B" };

            // Act/Assert:
            EqualityMethodsTestHelper(newA, null, false);
            EqualityMethodsTestHelper(newA, newA, true);
            EqualityMethodsTestHelper(newA, "String", false);
            EqualityMethodsTestHelper(newA, newB, false);
            EqualityMethodsTestHelper(newB, savedB, false);
            EqualityMethodsTestHelper(savedA1, savedA1, true);
            EqualityMethodsTestHelper(savedA1, savedA2, false);
            EqualityMethodsTestHelper(savedA1, savedB, false);
        }

        /// <summary>
        /// Test the GetHashCode method
        /// </summary>
        [TestMethod]
        public void GetHashCodeTest()
        {
            // Arrange:
            var newItem1 = new TestBusinessObject { Name = "A" };
            var newItem2 = new TestBusinessObject { Name = "A" };
            var savedItem = new TestBusinessObject { Id = 1, Name = "A" };
            
            // Act/Assert:
            Assert.AreNotEqual(newItem1.GetHashCode(), newItem2.GetHashCode());
            Assert.AreEqual(savedItem.Id.GetHashCode(), savedItem.GetHashCode());
        }

        /// <summary>
        /// Helper to test the equality operators
        /// </summary>
        /// <param name="item1">The first item to test</param>
        /// <param name="item2">The second item to test</param>
        /// <param name="expectEqual">Whether the items are expected to be equal</param>
        private static void EqualityOperatorsTestHelper(BusinessObject item1, BusinessObject item2, bool expectEqual)
        {
            var equalityOperator = item1 == item2;
            var inequalityOperator = item1 != item2;
            
            Assert.AreEqual(expectEqual, equalityOperator);
            Assert.AreEqual(!expectEqual, inequalityOperator);
        }

        /// <summary>
        /// Helper to test the equality methods
        /// </summary>
        /// <param name="item1">The first item to test</param>
        /// <param name="item2">The second item to test</param>
        /// <param name="expectEqual">Whether the items are expected to be equal</param>
        private static void EqualityMethodsTestHelper(BusinessObject item1, object item2, bool expectEqual)
        {
            var equalsMethod1 = item1.Equals(item2);
            var equalsMethod2 = item1.Equals(item2);

            Assert.AreEqual(expectEqual, equalsMethod1);
            Assert.AreEqual(expectEqual, equalsMethod2);
        }

        /// <summary>
        /// Test business object
        /// </summary>
        private class TestBusinessObject : BusinessObject
        {
            /// <summary>
            /// Gets or sets the name
            /// </summary>
            public string Name { get; set; }
        }
    }
}
