using System;
using System.Collections;
using System.Collections.Generic;
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
            IList<CakeType> cakeTypes = new List<CakeType>();
            CakeType typeA = new CakeType(7, 160);
            CakeType typeB = new CakeType(3, 90);
            CakeType typeC = new CakeType(2, 15);
            cakeTypes.Add(typeA);
            cakeTypes.Add(typeB);
            cakeTypes.Add(typeC);

            // Act
            CakeThief c = new CakeThief();
            int maxValue = c.MaxDuffelBagValue(cakeTypes, 20);

            // Assert
            Assert.AreEqual(555, maxValue);
        }

        [TestMethod]
        public void MaxDuffelBagValue_HigherValueWithLowerWeight_OptimalValueReturned()
        {
            // Arrange
            IList<CakeType> cakeTypes = new List<CakeType>();
            CakeType typeA = new CakeType(1, 30);
            CakeType typeB = new CakeType(50, 200);
            cakeTypes.Add(typeA);
            cakeTypes.Add(typeB);

            // Act
            CakeThief c = new CakeThief();
            int maxValue = c.MaxDuffelBagValue(cakeTypes, 100);

            // Assert
            Assert.AreEqual(3000, maxValue);
        }

        [TestMethod]
        public void MaxDuffelBagValue_OptimalValueUsingOneType_OptimalValueReturned()
        {
            // Arrange
            IList<CakeType> cakeTypes = new List<CakeType>();
            CakeType typeA = new CakeType(3, 40);
            CakeType typeB = new CakeType(5, 70);
            cakeTypes.Add(typeA);
            cakeTypes.Add(typeB);

            // Act
            CakeThief c = new CakeThief();
            int maxValue = c.MaxDuffelBagValue(cakeTypes, 9);

            // Assert
            Assert.AreEqual(120, maxValue);
        }
    }
}
