using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples.DesignPatterns.IteratorPattern;

namespace C_Sharp_Examples_Tests.DesignPatterns
{
    [TestClass]
    public class IteratorPatternTests
    {
        [TestMethod]
        public void IteratorPattern_IterateBothLists_PrintsFullOutput()
        {
            // ARRANGE
            WaitressClient client = new WaitressClient(new PancakeHouseMenu(), new DinnerMenu());

            // ACT
            string output = client.PrintMenu();
            string expectedOutput =
                "K & B's Pancake Breakfast    Pancakes with scrambled eggs, and toast    True    £2.99\r\n" +
                "Regular Pancake Breakfast    Pancakes with fried eggs, and sausage    False    £2.99\r\n" +
                "Roast Dinner    Beef, Chicken, Turkey, Vegetables and Sauce    False    £9.99\r\n" +
                "Chips and Salad    Fried chips and fresh salad    True    £4.99\r\n";

            // ASSERT
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
