using System;
using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            string[] seperatedValueStrings;

            if (input.Contains("//"))
            {
                var delimiter = input.Substring(input.IndexOf("//", System.StringComparison.Ordinal) + 2, 1).ToCharArray();
                input = input.Remove(0, 4);
                seperatedValueStrings = input.Split(delimiter);

            }
            else
            {
                seperatedValueStrings = input.Split(new char[] {',', '\n'});
            }

            var negativeNumbersList = (from seperatedValueString in seperatedValueStrings where int.Parse(seperatedValueString) < 0 select int.Parse(seperatedValueString)).ToList();

            if (negativeNumbersList.Count == 0) return seperatedValueStrings.Sum(s => int.Parse(s));
            var negativesNotAllowedException = new NegativesNotAllowedException(negativeNumbersList[0]);

            throw negativesNotAllowedException;
        }
    }
}
