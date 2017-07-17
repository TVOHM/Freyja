using Freyja.Numerics;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreyjaUnitTestProject
{
    [TestClass]
    public class IntegerDistributionTests
    {
        [TestMethod, TestCategory(nameof(IntegerDistributionTests))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_ThrowArgumentOutOfRangeException_When_Threshold_IsNegative()
        {
            new IntegerDistribution(-1);
        }
    }
}
