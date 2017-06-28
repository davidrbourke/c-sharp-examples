using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples;
using static C_Sharp_Examples.CloningExample;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class CloningExampleTests
    {
        [TestMethod]
        public void UseMemberCloneWise_ValidPerson_ReferenceReturned()
        {
            // Arrange
            CloningExample cloning = new CloningExample();
            var personA = new CloneablePerson
            {
                PersonId = 1,
                Email = "a@a.com",
                Age = 30,
                Address = new Address
                {
                    Street = "Farren Rd"
                }
            };

            // Act
            var personB = cloning.UseMemberCloneWise(personA);

            // Assert
            Assert.AreNotEqual(personA.Age, personB.Age);

            Assert.AreEqual(personA.Address, personB.Address);
        }

        [TestMethod]
        public void DeepCopyWithICloneable_ValidPerson_ReferenceReturned()
        {
            // Arrange
            CloningExample cloning = new CloningExample();
            var personA = new CloneablePerson
            {
                PersonId = 1,
                Email = "a@a.com",
                Age = 30,
                Address = new Address
                {
                    Street = "Farren Rd"
                }
            };

            // Act
            var personB = cloning.DeepCopyWithICloneable(personA);

            // Assert
            Assert.AreNotEqual(personA.Age, personB.Age);

            Assert.AreNotEqual(personA.Address, personB.Address);
        }
    }
}
