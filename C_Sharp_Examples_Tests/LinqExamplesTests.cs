using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class LinqExamplesTests
    {
        [TestMethod]
        public void SimpleSampleTest()
        {
            LinqExamples example = new LinqExamples();
            example.SimpleSample();
        }

        [TestMethod]
        public void ClassSampleTest()
        {
            LinqExamples example = new LinqExamples();
            example.ClassSample();
        }

        [TestMethod]
        public void LinqToXmlSample()
        {
            LinqExamples example = new LinqExamples();
            example.LingToXmlSample();
        }

        [TestMethod]
        public void LinqToSqlSample()
        {
            LinqExamples example = new LinqExamples();
            example.LinqToSqlSample();
        }
    }
}
