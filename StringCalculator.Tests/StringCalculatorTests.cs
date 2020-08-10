using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private Core.StringCalculator strCalc;

        [TestInitialize]
        public void Setup()
        {
            strCalc = new Core.StringCalculator();
        }

        [TestMethod]
        public void Given_When_An_Empty_String_Then_Return_Zero()
        {
            var expected = 0;
            var actual = strCalc.Add(string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_When_A_Single_Number_Then_Return_Number()
        {
            var expected = 1;
            var actual = strCalc.Add("1");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_When_Two_Numbers_Then_Return_Sum_Of_Two_Numbers()
        {
            var expected = 3;
            var actual = strCalc.Add("1,2");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_When_Multiple_Numbers_Then_Return_Sum_Of_All_Numbers()
        {
            var expected = 6;
            var actual = strCalc.Add("1,2,3");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_New_Line_As_A_Delimeter_Then_Return_Sum_Of_All_Numbers()
        {
            var expected = 6;
            var actual = strCalc.Add("1\n2,3");

            Assert.AreEqual(expected, actual);
        }
    }
}