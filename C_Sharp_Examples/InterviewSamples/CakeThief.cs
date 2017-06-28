using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.InterviewSamples
{
    //https://www.interviewcake.com/question/csharp/cake-thief?utm_source=weekly_email&utm_campaign=weekly_email&utm_medium=email
    public class CakeThief
    {
        public long MaxDuffelBagValue(CakeType[] cakeTypes, int capacity)
        {
            // Sort by most valueable ratio
            var sortedList = cakeTypes.ToList().OrderByDescending(x => x.Ratio);
            int valueInBag = 0;
            int weightInBag = 0;
            foreach (var cakeType in sortedList)
            {
                decimal fit = Math.Floor((decimal)(capacity / cakeType.Weight));
                if (fit >= 1)
                {
                    weightInBag += Convert.ToInt32(fit * cakeType.Weight);
                    valueInBag = valueInBag + Convert.ToInt32(fit * cakeType.Value);
                    capacity = capacity - weightInBag;
                }
                if (fit < 1 && cakeType.Ratio == 1)
                    break;
            }

            return valueInBag;
        }

        public long MaxDuffelBagValueSolution(CakeType[] cakeTypes, int weightCapacity)
        {
            // We make an array to hold the maximum possible value at every
            // duffel bag weight capacity from 0 to weightCapacity.
            // Starting each index with value 0.
            long[] maxValuesAtCapacities = new long[weightCapacity + 1];

            for (int currentCapacity = 0; currentCapacity <= weightCapacity; currentCapacity++)
            {
                // Set a variable to hold the max monetary value so far for currentCapacity
                long currentMaxValue = 0;

                foreach (var cakeType in cakeTypes)
                {
                    // If a cake weighs 0 and has a positive value the value of our duffel bag is infinite!
                    if (cakeType.Weight == 0 && cakeType.Value != 0)
                    {
                        throw new InfinityException();
                    }

                    // If the current cake weighs as much or less than the current weight capacity
                    // it's possible taking the cake would give get a better value
                    if (cakeType.Weight <= currentCapacity)
                    {
                        // So we check: should we use the cake or not?
                        // If we use the cake, the most kilograms we can include in addition to the cake
                        // we're adding is the current capacity minus the cake's weight. We find the max
                        // value at that integer capacity in our array maxValuesAtCapacities.
                        long maxValueUsingCake = cakeType.Value + maxValuesAtCapacities[currentCapacity - cakeType.Weight];

                        // Now we see if it's worth taking the cake. how does the
                        // value with the cake compare to the currentMaxValue?
                        currentMaxValue = Math.Max(maxValueUsingCake, currentMaxValue);
                    }
                }

                // Add each capacity's max value to our array so we can use them
                // when calculating all the remaining capacities
                maxValuesAtCapacities[currentCapacity] = currentMaxValue;
            }

            return maxValuesAtCapacities[weightCapacity];
        }
    }

    public class CakeType
    {
        public int Weight { get; }
        public long Value { get; }

        public float Ratio
        {
            get { return Value / Weight; }
        }

        public CakeType(int weight, long value)
        {
            Weight = weight;
            Value = value;
        }
    }

    public class InfinityException : Exception
    {
        public InfinityException() :
            base("Max value is infinity!")
        {
        }
    }
}
