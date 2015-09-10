using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Examples;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class DelegateExampleTests
    {
        [TestMethod]
        public void DoTheWork_ForTheDelegate()
        {
            DelegateExample delegateExample = new DelegateExample();
            delegateExample.DoTheWork();

            delegateExample.MyDelegateFunction();
        }
    }
}
