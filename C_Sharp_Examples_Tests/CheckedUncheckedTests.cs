using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class CheckedUncheckedTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            checked
            {
                short sh = Int16.MaxValue;
                short nsh = (short) (sh + 1);
            }
        }
    }
}
