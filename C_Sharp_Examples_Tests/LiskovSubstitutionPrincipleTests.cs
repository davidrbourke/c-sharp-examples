using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication3;
using System.Collections.Generic;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class LiskovSubstitutionPrincipleTests
    {
        [TestMethod]
        public void ExampleFailsLiskovSubstitutionPrinciple()
        {
            // ARRANGE
            LiskovSubsitutionPrinciple lsp = new LiskovSubsitutionPrinciple();
            // ACT
            IList<Rectangle> shapes = lsp.ExampleFailsLiskovSubstitutionPrinciple();
            int rectangleArea = shapes[0].GetArea();
            int squareArea = (shapes[1] as Rectangle).GetArea();

            // ASSERT
            Assert.AreEqual(200, rectangleArea);
            Assert.AreEqual(100, squareArea);

            // Although we have cast to a Rectangle, the subtitution has resulted in the bahviour changing 
            // as the second object returns the functionality of the Square
        }

        [TestMethod]
        public void ExamplePassesLiskovSubstitutionPrinciple()
        {
            // ARRANGE
            LiskovSubsitutionPrinciple lsp = new LiskovSubsitutionPrinciple();
            // ACT
            IList<Shape> shapes = lsp.ExamplePassesLiskovSubstitutionPrinciple();
            int rectangleArea = shapes[0].GetArea();
            int squareArea = (shapes[1]).GetArea();

            // ASSERT
            Assert.AreEqual(200, rectangleArea);
            Assert.AreEqual(100, squareArea);

            // Although we get the same result, each class has different behaviour BUT 
            // now we don't have the problem of the subclass resutling in different bahviour compared
            // to the base class, as the base class is Abstract
        }
    }
}
