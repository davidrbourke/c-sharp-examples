using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples.DesignPatterns.TemplatePattern;

namespace C_Sharp_Examples_Tests.DesignPatterns
{
    [TestClass]
    public class TemplatePatternTests
    {
        [TestMethod]
        public void TemplatePattern_Coffee_True()
        {
            // ARRANGE
            Coffee coffee = new Coffee();

            // ACT
            coffee.PrepareRecipe();
            string output = coffee.ToString();

            // ASSERT
            Assert.AreEqual("Boiling Water\r\n" +
                "Add in coffee\r\n" +
                "Pouring into Cup\r\n" +
                "Add in sugar and Milk\r\n", output);

        }

        [TestMethod]
        public void TemplatePattern_Tea_True()
        {
            // ARRANGE
            Tea tea = new Tea();

            // ACT
            tea.PrepareRecipe();
            string output = tea.ToString();

            // ASSERT
            Assert.AreEqual("Boiling Water\r\n" +
                "Add in tea bag and soak, remove tea bag\r\n" +
                "Pouring into Cup\r\n" +
                "Squeeze in Lemon juice\r\n", output);
        }
    }
}
