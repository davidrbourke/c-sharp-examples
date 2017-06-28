using System.Collections.Generic;
using System.Linq;
using C_Sharp_Examples.InterviewSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests.InterviewSamples
{
    [TestClass]
    public class CakeThiefTests
    {
        [TestMethod]
        public void MaxDuffelBagValue_FullBagPossible_FullBagReturned()
        {
            // Arrange
            CakeType[] cakeTypes =
            {
                new CakeType(7, 160),
                new CakeType(3, 90),
                new CakeType(2, 15)
            };

            // Act
            CakeThief c = new CakeThief();
            long maxValue = c.MaxDuffelBagValue(cakeTypes, 20);

            // Assert
            Assert.AreEqual(555, maxValue);
        }

        [TestMethod]
        public void MaxDuffelBagValue_HigherValueWithLowerWeight_OptimalValueReturned()
        {
            // Arrange
            CakeType[] cakeTypes =
            {
                new CakeType(1, 30),
                new CakeType(50, 200)
            };

            // Act
            CakeThief c = new CakeThief();
            long maxValue = c.MaxDuffelBagValue(cakeTypes, 100);

            // Assert
            Assert.AreEqual(3000, maxValue);
        }

        [TestMethod]
        public void MaxDuffelBagValue_OptimalValueUsingOneType_OptimalValueReturned()
        {
            // Arrange
            CakeType[] cakeTypes =
            {
                new CakeType(3, 40),
                new CakeType(5, 70)
            };

            // Act
            CakeThief c = new CakeThief();
            long maxValue = c.MaxDuffelBagValue(cakeTypes, 9);

            // Assert
            Assert.AreEqual(120, maxValue);
        }
    }
}
