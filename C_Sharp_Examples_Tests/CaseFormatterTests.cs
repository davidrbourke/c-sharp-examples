using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication3;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class CaseFormatterTests
    {
        [TestMethod]
        public void FormatString_FormattedFromLower()
        {
            // ARRANGE
            CaseFormatter caseFormatter = new CaseFormatter();

            // ACT
            string line = caseFormatter.FormatString("this is at the end of the line");

            // ASSERT
            Assert.AreEqual("This Is at the End Of the Line", line);
        }

        [TestMethod]
        public void FormatString_FormattedFromUpper()
        {
            // ARRANGE
            CaseFormatter caseFormatter = new CaseFormatter();

            // ACT
            string line = caseFormatter.FormatString("IN THE END wE All GO THE sAmE WaY");

            // ASSERT
            Assert.AreEqual("In the End We All Go the Same Way", line);
        }
    }
}
