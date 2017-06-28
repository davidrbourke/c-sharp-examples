using System;
using C_Sharp_Examples.InterviewSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests.InterviewSamples
{
    [TestClass]
    public class ShufflerTests
    {
        [TestMethod]
        public void Shuffle_Array_IsShuffled()
        {
            // Arrange
            var list = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var shuffler = new Shuffler();

            // Act
            var shuffledList = shuffler.Shuffle(list);
        }
    }
}
