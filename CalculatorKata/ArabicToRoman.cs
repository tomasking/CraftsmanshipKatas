using System.Collections.Generic;

namespace CraftsmanKata
{
    public class ArabicToRoman
    {
        private readonly Dictionary<int, string> arabicToRoman = new Dictionary<int, string>()
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
            {1, "I"},
        };

        public string Convert(int number)
        {
            foreach (var pair in arabicToRoman)
            {
                if (number >= pair.Key)
                {
                    return pair.Value + Convert(number - pair.Key);
                }
            }

            return string.Empty;
        }
    }
}