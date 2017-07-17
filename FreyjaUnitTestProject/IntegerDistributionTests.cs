using Freyja.Numerics;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreyjaUnitTestProject
{
    [TestClass]
    public class IntegerDistributionTests
    {
        [TestMethod, TestCategory(nameof(IntegerDistributionTests))]
        public void Clear_Should_RemoveAllValuesAndCounts()
        {
            var d = new IntegerDistribution(100);
            d.Update(123);
            d.Update(123);
            d.Update(456);
            d.Update(789);
            d.Update(456);
            d.Update(123);
            d.Update(123);
            d.Update(456);
            d.Update(789);
            d.Update(456);
            d.Clear();
            Assert.IsFalse(d.Any());
        }

        [TestMethod, TestCategory(nameof(IntegerDistributionTests))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_ThrowArgumentOutOfRangeException_When_Threshold_IsNegative()
        {
            new IntegerDistribution(-1);
        }

        [TestMethod, TestCategory(nameof(IntegerDistributionTests))]
        public void GetEnumerator_Should_ReturnAllValuesAndCounts()
        {
            var d = new IntegerDistribution(100);
            d.Update(123);
            d.Update(123);
            d.Update(456);
            d.Update(789);
            d.Update(456);
            d.Update(123);
            d.Update(123);
            d.Update(456);
            d.Update(789);
            d.Update(456);
            d.Clear();
            Assert.IsFalse(d.Any());
        }

        [TestMethod, TestCategory(nameof(IntegerDistributionTests))]
        public void Update_Should_AddNewValue_WithCountOne()
        {
            var d = new IntegerDistribution(100);
            d.Update(123);
            d.Update(456);
            d.Update(456);
            d.Update(789);
            Assert.AreEqual((123, 1), d.Single(vcp => vcp.value == 123));
        }

        [TestMethod, TestCategory(nameof(IntegerDistributionTests))]
        public void Update_Should_UpdatedExistingValue()
        {
            var d = new IntegerDistribution(100);
            d.Update(123);
            d.Update(456);
            d.Update(123);
            d.Update(123);
            d.Update(123);
            d.Update(123);
            d.Update(456);
            d.Update(789);
            d.Update(456);
            Assert.AreEqual((123, 5), d.Single(vcp => vcp.value == 123));
        }
    }
}
