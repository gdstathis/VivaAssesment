using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMaxFinder
{
    public class SecondMaxFinder
    {
        public int? FindSecondMax(IEnumerable<int> numbers)
        {
            if (numbers == null || numbers.Count() == 0) return null;
            int? max = null;
            int? secondMax = null;
            foreach (int num in numbers)
            {
                if (max == null || num > max)
                {
                    secondMax = max;
                    max = num;
                }
                else if (secondMax == null || num > secondMax)
                {
                    secondMax = num;
                }
            }
            return secondMax ?? default;
        }
    }
}
