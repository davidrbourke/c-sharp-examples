using System;
using System.Threading.Tasks;
using C_Sharp_Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class ConcurrencyTests
    {
        [TestMethod]
        public void WriteLargeFiles_()
        {
            // Arrange
            Concurrency concurrency = new Concurrency();

            // Act
            long milliseconds  = concurrency.GetTimeOfWritingLargeFiles();

            
        }

        [TestMethod]
        public void GetTimeOfLongRunningMethodAsync_()
        {
            // Arrange
            Concurrency concurrency = new Concurrency();

            // Act
            Task<long> millisecondsTask =  concurrency.GetTimeOfLongRunningMethodAsync();
            
            // Assert
            Assert.IsTrue(millisecondsTask.Result > 4000);
        }

        [TestMethod]
        public void GetTimeOfLongRunningMethodWithWhenAllAsync_()
        {
            // Arrange
            Concurrency concurrency = new Concurrency();

            // Act
            Task<long> millisecondsTask = concurrency.GetTimeOfLongRunningMethodAsync();

            // Assert
            Assert.IsTrue(millisecondsTask.Result > 2000 && millisecondsTask.Result < 4000);
        }
    }
}
