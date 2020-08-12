using System;
using System.Linq;
using System.Text;

namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            //Replace all '\n' with ',' and check if new delimiter is requested
            //Throws exceptiion if requested delimiter is not allowed
            numbers = HandleString(numbers);

            //Throws exception if "-" is present in the string
            CheckNegativeNumbers(numbers);

            //Removes all numbers larger than 1000 from the string
            numbers = RemoveLargeNumbers(numbers);

            return Sum(SplitString(numbers));
        }

        private static string HandleString(string numbers)
        {
            //Replace all newlines with the default delimiter to simplify expression handling
            numbers = numbers.Replace("\n", ",");

            if (numbers.StartsWith("//["))
            {
                //Extract the delimiter string between the brackets
                string delimiter = numbers.Substring(3, numbers.IndexOf("]"));

                //Check for any illegal delimiter
                if (delimiter.Contains("-"))
                    throw new ArgumentException($"Illegal delimiter: {delimiter}");

                //Throw away the "//[delimiter]\n" part
                numbers = numbers.Substring(5 + delimiter.Length);

                //Replace all instances of the new delimiter with default one
                numbers = numbers.Replace(delimiter, ",");
            }

            if (numbers.StartsWith("//"))
            {
                //Check if string contains int
                if (IsStringContainsInt(numbers) == "0") return "0";

                //Extract new delimiter
                string delimiter = numbers.Substring(2, 3);

                //Check for the illegal delimiter
                if(delimiter.Contains("-"))
                    throw new ArgumentException($"Illegal delimiter: {delimiter}");

                //Throw away the "//[delimiter]\n" part
                numbers = numbers.Substring(4);

                //Replace all instances of the new delimiter with default one
                numbers = numbers.Replace(delimiter, ",");
            }

            return numbers;
        }

        private static void CheckNegativeNumbers(string numbers)
        {
            string[] negNums = SplitString(numbers);

            string negatives = "";

            foreach(var negNum in negNums)
            {
                if (negNum.Contains("-"))
                {
                    negatives += negNum + ",";
                }
            }

            if (negatives.Count() > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {negatives.TrimEnd(',')}");
            }
        }

        private static string RemoveLargeNumbers(string numbers)
        {
            StringBuilder fixedString = new StringBuilder();

            string[] nums = SplitString(numbers);

            foreach(string num in nums)
            {
                if(ToInt(num) <= 1000)
                {
                    fixedString.Append(num + ",");
                }
            }

            return fixedString.ToString();
        }

        private static string[] SplitString(string numbers)
        {
            string[] nums = numbers.Split(new char[] { ',', ';', '%', '*' });

            return nums;
        }

        private static int ToInt(string number)
        {
            return int.Parse(IsNotNullString(number));
        }

        private static int Sum(string[] numbers)
        {
            int sum = 0;

            foreach(string number in numbers)
            {
                sum += ToInt(number);
            }

            return sum;
        }

        private static string IsNotNullString(string number)
        {
            return string.IsNullOrEmpty(number.ToString()) ? "0" : number;
        }

        private static string IsStringContainsInt(string numbers)
        {
            var result = new String(numbers.Where(Char.IsDigit).ToArray());

            return string.IsNullOrEmpty(result) ? "0" : result;
        }
    }
}
