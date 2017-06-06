using System;
using C_Sharp_Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class CSharp7FeaturesTests
    {
        [TestMethod]
        public void OutVariables_ValidIntSupplied_IntReturned()
        {
            // Arrange
            CSharp7Features features = new CSharp7Features();

            // Act
            int? result = features.OutVariables("1234");

            // Assert
            Assert.AreEqual(1234, result);
        }

        [TestMethod]
        public void Tuples_()
        {
            // Arrange
            CSharp7Features features = new CSharp7Features();

            // Act
            features.TuplesExample();
        }
    }
}
