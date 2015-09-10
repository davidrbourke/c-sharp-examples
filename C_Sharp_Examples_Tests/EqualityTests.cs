using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class EqualityTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // ASSERT
            Equality eq = new Equality();
            EqualityObject ea = new EqualityObject
            {
                Id = 1,
                Name = "David"
            };

            EqualityObject eb = new EqualityObject
            {
                Id = 1,
                Name = "David"
            };

            // ARRANGE
            var ec = ea.CloneMe();
            var eatype = ec.GetType().ToString();

            bool areEqual = eq.AreObjectsEqual(ea, eb);

            // ACT
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Method2()
        {
            B b1 = new D();
            D d1 = (D)b1;
        }

        internal class B
        {

        }

        internal class D : B
        {

        }
    }
}
