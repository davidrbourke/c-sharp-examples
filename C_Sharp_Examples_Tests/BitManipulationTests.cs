using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication3;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class BitManipulationTests
    {
        [TestMethod]
        public void ShiftLeftOnePlace()
        {
            // ARRANGE

            BitManipulation bitM = new BitManipulation();

            // ACT
            int shifted = bitM.ShiftLeftOnePlace(1);
            
            // ASSERT
            Assert.AreEqual(2, shifted);
        }

        [TestMethod]
        public void ShiftLeftTwoPlaces()
        {
            // ARRANGE

            BitManipulation bitM = new BitManipulation();

            // ACT
            int shifted = bitM.ShiftLeftTwoPlaces(1);

            // ASSERT
            Assert.AreEqual(4, shifted);
        }

        [TestMethod]
        public void ConvertBase10ToBinary()
        {
            // ARRANGE
            BitManipulation bitM = new BitManipulation();

            // ACT
            string binaryString = bitM.ConvertBase10ToBinary(123);
            
            // ASSERT
            Assert.AreEqual("01111011", binaryString);
        }


        [TestMethod]
        public void BitAnd()
        {
            // ARRANGE
            BitManipulation bitM = new BitManipulation();

            // ACT
            int comparedBit = bitM.AndBit(3, 5);

            // ASSERT
            Assert.AreEqual(1, comparedBit);
        }

        [TestMethod]
        public void BitOr()
        {
            // ARRANGE
            BitManipulation bitM = new BitManipulation();

            // ACT
            int comparedBit = bitM.OrBit(3, 5);

            // ASSERT
            Assert.AreEqual(7, comparedBit);
        }

        [TestMethod]
        public void BitXOr()
        {
            // ARRANGE
            BitManipulation bitM = new BitManipulation();

            // ACT
            int comparedBit = bitM.XOrBit(3, 5);

            // ASSERT
            Assert.AreEqual(6, comparedBit);
        }

        [TestMethod]
        public void BitNot()
        {
            // ARRANGE
            BitManipulation bitM = new BitManipulation();

            // ACT
            int comparedBit = bitM.NotBit(52);

            // ASSERT
            Assert.AreEqual(11, comparedBit);
        }

        [TestMethod]
        public void CountNumberOfOnesInNumber()
        {
            // ARRANGE
            BitManipulation bitM = new BitManipulation();

            // ACT
            int countedOnes = bitM.CountNumberOfOnesInNumber(123);
            
            // ASSERT
            Assert.AreEqual(6, countedOnes);

        }
    }
}
