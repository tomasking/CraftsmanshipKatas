using System.Linq;

namespace CraftsmanKata.CalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numbersArray = numbers.Split(',');
            int result = numbersArray.Sum(int.Parse);
            return result;
        }
    }
}