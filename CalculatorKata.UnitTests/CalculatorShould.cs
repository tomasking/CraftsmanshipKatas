using FluentAssertions;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests
{
    [TestFixture]
    public class CalculatorShould
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Return_0_Given_An_Empty_String()
        {

            int result = calculator.Add(string.Empty);

            result.Should().Be(0);
        }

        [TestCase("0,0", 0)]
        [TestCase("2,5", 7)]
        public void Return_Sum_Given_Two_Comma_Separated_Numbers_As_String(string numbers, int expected)
        {
            var result = calculator.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("10", 10)]
        public void Return_Integer_Given_Single_Number_As_String(string number, int expected)
        {
            var result = calculator.Add(number);

            result.Should().Be(expected);
        }

        [TestCase("1,2,3", 6)]
        public void Return_Sum_Given_Multiple_Comma_Separated_Numbers_As_String(string numbers, int expected)
        {
            var result = calculator.Add(numbers);

            result.Should().Be(expected);
        }
    }
}
