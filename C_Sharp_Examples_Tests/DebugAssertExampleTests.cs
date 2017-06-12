using System;
using C_Sharp_Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class DebugAssertExampleTests
    {
        [TestMethod]
        public void ExecutionAssertion_BothZeroInputs_DebugOutputs()
        {
            // Arrange
            DebugAssertExample assertExample = new DebugAssertExample();

            // Act
            int result = assertExample.ExecuteAssertion(0, 0);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ExecutionAssertion_NonZeroInputs_DebugDoesNotOutput()
        {
            // Arrange
            DebugAssertExample assertExample = new DebugAssertExample();

            // Act
            int result = assertExample.ExecuteAssertion(10, 12);

            // Assert
            Assert.AreEqual(120, result);
        }
    }
}
