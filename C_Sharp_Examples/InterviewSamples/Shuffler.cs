using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.InterviewSamples
{
    public class Shuffler
    {
        private Random _rand;
        public Shuffler()
        {
            _rand = new Random(65245);
        }
        public int[] Shuffle(int[] list)
        {
            for (int i = 0; i < list.Length/2; i++)
            {
                int randInt = _rand.Next(0, list.Length-1);
                int item = list[i];
                list[i] = list[randInt];
                list[randInt] = item;
            }
            return list;
        }
    }
}
