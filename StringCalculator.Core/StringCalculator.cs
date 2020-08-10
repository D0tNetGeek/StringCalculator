using System;
using System.Linq;

namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            if (numbers.Contains(","))
                return numbers.Split(',').Select(x=>int.Parse(x)).Sum();
            return 1;
        }
    }
}
