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
        public int MaxDuffelBagValue(IEnumerable<CakeType> cakeTypes, int capacity)
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
}
