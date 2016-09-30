using FluentAssertions;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests
{
    [TestFixture]
    public class ArabicToRomanShould
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(19, "XIX")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(24, "XXIV")]
        [TestCase(40, "XL")]
        [TestCase(41, "XLI")]
        [TestCase(50, "L")]
        [TestCase(51, "LI")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(400, "CD")]
        [TestCase(500, "D")]
        [TestCase(900, "CM")]
        [TestCase(1000, "M")]
        [TestCase(846, "DCCCXLVI")]
        [TestCase(1999, "MCMXCIX")]
        [TestCase(2008, "MMVIII")]
        public void ReturnNumeral_GivenWeHaveEntered(int inputNumber, string expectedOutput)
        {
            string result = new ArabicToRoman2().Convert(inputNumber);

            result.Should().Be(expectedOutput);
        }
     }
}
