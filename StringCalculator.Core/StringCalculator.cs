using System;
using System.Linq;

namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var delimiters = ",\n";

            if (IsEmptyString(numbers))
                return HandleEmptyString();

            if (numbers.Contains("//"))
            {
                delimiters += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);
            }

            var nums = numbers.Split(delimiters.ToCharArray());

            if (nums.Any(x => string.IsNullOrEmpty(x)))
                throw new ArgumentException("Consecutive delimiters not allowed.");

            var ints = nums.Select(x => int.Parse(x));
            var negNums = ints.Where(x => x < 0);

            if (negNums.Count() > 0)
            {
                var message = $"Negatives not allowed - {string.Join(",",negNums.Select(x=>x.ToString()).ToArray())}";

                throw new ArgumentOutOfRangeException(message);
            }

            if (ints.Any(x => x < 0))
                throw new ArgumentOutOfRangeException();

            return nums.Select(x=>int.Parse(x)).Sum();
        }

        private static int HandleEmptyString()
        {
            return 0;
        }

        private static bool IsEmptyString(string numbers)
        {
            return numbers.Length == 0;
        }
    }
}
