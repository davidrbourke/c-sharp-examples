using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class ConstructorExamplesTests
    {
        [TestMethod]
        public void SimpleSubClassExamples_Construct()
        {
            ConstructorExamples constructorExamples = new ConstructorExamples();
            constructorExamples.SimpleSubClassExample();
        }
    }
}
