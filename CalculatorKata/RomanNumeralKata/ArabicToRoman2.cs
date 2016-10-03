using System.Collections.Generic;

namespace CraftsmanKata.RomanNumeralKata
{
    public class ArabicToRoman2
    {
        private readonly Dictionary<int, string> romanToArabic = new Dictionary<int, string>()
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

        public string Convert(int number)
        {
            string result = string.Empty;

            foreach (var lookup in romanToArabic)
            {
                while (number >= lookup.Key)
                {
                    result += lookup.Value;
                    number = number - lookup.Key;
                }
            }

            return result;
        }
    }


}