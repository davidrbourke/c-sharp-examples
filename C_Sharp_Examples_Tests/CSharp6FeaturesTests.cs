using System;
using C_Sharp_Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class CSharp6FeaturesTests
    {
        [TestMethod]
        public void NullConditionalOperators()
        {
            // Arrange
            CSharp6Features features = new CSharp6Features();

            // Act
            string resultAsStr = features.NullConditionalOperatorsForString();
            int? resultAsInt = features.NullConditionalOperatorsForInteger();

            // Assert
            Assert.IsNull(resultAsStr);
            Assert.IsNull(resultAsInt);
        }
    }
}
