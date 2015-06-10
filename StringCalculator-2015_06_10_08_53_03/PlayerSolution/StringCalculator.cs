using System;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var seperatedValues = new[] {""};

            if (input.Contains(",") || input.Contains("\n")) seperatedValues = input.Split(new Char[] { ',', '\n' });

            if (string.IsNullOrEmpty(seperatedValues.First())) return int.Parse(input);
            
            return seperatedValues.Sum(number => int.Parse(number));
        }
    }
}
