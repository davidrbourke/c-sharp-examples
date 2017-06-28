using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class BitManipulation
    {
        public int ShiftLeftOnePlace(int input)
        {
            return input << 1;
        }

        public int ShiftLeftTwoPlaces(int input)
        {
            return input << 2;
        }

        public string ConvertBase10ToBinary(int input)
        {
            int[] bits = { 128, 64, 32, 16, 8, 4, 2, 1 };

            StringBuilder sb = new StringBuilder();
            foreach(int b in bits)
            {
                if(b > input)
                {
                    sb.Append("0");
                }
                else
                {
                    sb.Append("1");
                    input -= b;
                }
            }
            return sb.ToString();
        }

        

        public int AndBit(int input, int comparedInput)
        {
            return input & comparedInput;
        }

        public int OrBit(int input, int comparedInput)
        {
            return input | comparedInput;
        }

        public int XOrBit(int input, int comparedInput)
        {
            return input ^ comparedInput;
        }

        public int CountNumberOfOnesInNumber(int input)
        {
            int counter = 0;
            int andedWithOne = input & 1;
            while(input != 0)
            {
                if (andedWithOne == 1)
                {
                    counter += 1;
                }
                int i = input >> 1;
                input = i;

            }
            return counter;
        }

        public int NotBit(int input)
        {
            return ~input;
        }
    }
}
