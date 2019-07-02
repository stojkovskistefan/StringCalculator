using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Test
{
    internal class StringCalculator
    {
        public float Add(string input)
        {
            
            if (string.IsNullOrEmpty(input))
                return 0;
            else
            {
                String[] numbers = input.Split(",");
                return Sum(numbers);
            }
                
        }

        private float Sum(string[] numbers)
        {
            float sum=0;

            foreach(String value in numbers)
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidOperationException("Missing number in last position.");
                else
                    CheckIfNegative(numbers);

                sum += toNumber(value);
            }
            return sum;
        }

        private void CheckIfNegative(string[] numbers)
        {
            var spliitedLines = numbers.Select(n => toNumber(n));
            var negatives = LookForNegativeNumbers(spliitedLines);
            if (negatives.Any())
            {
                throw new ArgumentException(String.Format("Negatives are not allowed : {0}", String.Join(", ", negatives)));
            }
        }

        private float toNumber(String input)
        {
            return float.Parse(string.IsNullOrEmpty(input) ? "0" : input);
        }
        public static float[] LookForNegativeNumbers(IEnumerable<float> numbers)
        {
            return numbers.Where(n => n < 0).ToArray();
        }
    }
}