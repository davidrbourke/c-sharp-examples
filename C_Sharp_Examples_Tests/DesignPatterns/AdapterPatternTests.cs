using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication3.DesignPatterns.AdapterPattern;
using System.Collections.Generic;

namespace C_Sharp_Examples_Tests.DesignPatterns
{
    [TestClass]
    public class AdapterPatternTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // ARRANGE
            IDuck duck = new Duck();
            Turkey turkey = new Turkey();
            IDuck adaptedTurkey = new TurkeyAdapter(turkey);
            List<IDuck> ducks = new List<IDuck>();
            ducks.Add(duck);
            ducks.Add(adaptedTurkey);

            // ACT
            string duckFly = ducks[0].Fly();
            string duckQuack = ducks[0].Quack();
            string adaptedDuckFly = ducks[1].Fly();
            string adaptedDuckQuack = ducks[1].Quack();

            // ASSERT
        }
    }
}
