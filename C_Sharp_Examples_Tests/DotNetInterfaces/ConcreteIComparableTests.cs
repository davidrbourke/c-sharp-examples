using System;
using C_Sharp_Examples.DotNetInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests.DotNetInterfaces
{
    [TestClass]
    public class ConcreteIComparableTests
    {
        [TestMethod]
        public void DoComparison()
        {
            // Arrange
            var concreteComparable = new ConcreteIComparable();

            // Act
            concreteComparable.DoComparison();

        }
    }
}
