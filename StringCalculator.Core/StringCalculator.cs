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
            var delimiters = ",\n";

            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (numbers.Contains("//"))
            {
                delimiters += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);
            }

            var nums = numbers.Split(delimiters.ToCharArray());

            if (nums.Any(x => string.IsNullOrEmpty(x)))
                throw new ArgumentException("Consecutive delimiters not allowed.");

            var ints = nums.Select(x => int.Parse(x));

            if (ints.Any(x => x < 0))
                throw new ArgumentOutOfRangeException();

            return nums.Select(x=>int.Parse(x)).Sum();
        }
    }
}
