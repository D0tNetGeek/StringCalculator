using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private Core.StringCalculator strCalc;

        [SetUp]
        public void Setup()
        {
            strCalc = new Core.StringCalculator();
        }

        [Test]
        public void Given_When_An_Empty_String_Then_Return_Zero()
        {
            Assert.AreEqual(0, strCalc.Add(string.Empty));
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Given_When_A_Single_Number_Then_Return_Number(string numbers, int expected)
        {
            var actual = strCalc.Add(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2",3)]
        [TestCase("2,3", 5)]
        public void Given_When_Two_Numbers_Then_Return_Sum_Of_Two_Numbers(string numbers, int expected)
        {
            var actual = strCalc.Add(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,3",6)]
        [TestCase("2,3,4", 9)]
        public void Given_When_Multiple_Numbers_Then_Return_Sum_Of_All_Numbers(string numbers, int expected)
        {
            var actual = strCalc.Add(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_When_No_Number_With_Delimiter_Line_Then_Return_Zero()
        {
            var actual = strCalc.Add("//,\n");

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void Given_When_One_Number_With_Delimiter_Line_Then_Return_Number()
        {
            var actual = strCalc.Add("//,\n1");

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Given_When_New_Line_As_A_Delimiter_Then_Return_Sum_Of_All_Numbers()
        {
            var expected = 6;
            var actual = strCalc.Add("1\n2,3");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_When_A_Custom_Delimiter_Then_Return_Sum_Of_All_Numbers()
        {
            var expected = 3;
            var actual = strCalc.Add("//;\n1;2");

            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1, 2", "-1")]
        [TestCase("-1,-2,3", "-1,-2")]
        public void Given_When_A_Negative_Number_Then_Throw_Exception(string numbers, string expected)
        {
            var exception = Assert.Throws<ArgumentException>(() => strCalc.Add(numbers));

            Assert.AreEqual(exception.Message, $"Negatives not allowed: {expected}");
        }

        [TestCase("2,1000", 1002)]
        [TestCase("2,1001,13", 15)]
        public void Given_When_A_Large_Number_Greater_Than_1000_Then_Return_Sum_Of_All_Small_Numbers(string numbers, int expected)
        {
            var actual = strCalc.Add(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_When_Multiple_Delimiters_Present_Then_Return_Sum_Of_All_Numbers()
        {
            var expected = 6;
            var actual = strCalc.Add("//*%\n1*2%3");

            Assert.AreEqual(expected, actual);
        }
    }
}
