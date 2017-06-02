using System;
using System.IO;
using C_Sharp_Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class CSharp6FeaturesTests
    {
        [TestMethod]
        public void NullConditionalOperators()
        {
            // Arrange
            CSharp6Features features = new CSharp6Features();

            // Act
            string resultAsStr = features.NullConditionalOperatorsForString();
            int? resultAsInt = features.NullConditionalOperatorsForInteger();

            // Assert
            Assert.IsNull(resultAsStr);
            Assert.IsNull(resultAsInt);
        }

        [TestMethod]
        public void ExceptionFiltering_ExpectedFileNotFound_MessageSet()
        {
            // Arrange
            CSharp6Features features = new CSharp6Features();

            // Act
            string message = features.FileExceptionFilter(@"C:\doesnotexist.txt");

            // Assert
            Assert.AreEqual("File not found", message);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ExceptionFiltering_UnExpectedFileNotFound_MessageSet()
        {
            // Arrange
            CSharp6Features features = new CSharp6Features();

            // Act
            string message = features.FileExceptionFilter(@"C:\maynotexist.txt");
        }

        [TestMethod]
        public void NameOfExpressionExample()
        {
            // Arrange
            CSharp6Features features = new CSharp6Features();

            // Act
            string result = features.NameofExample(string.Empty);

            // Assert
            Assert.AreEqual("Not provided: itemName", result);
        }
    }
}
