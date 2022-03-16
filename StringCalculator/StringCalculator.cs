using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbersCollection)
        {
            List<int> negativeNumbers = new List<int>();
            var delimiters = new List<char> {',', '\n'};

            if (numbersCollection.StartsWith("//"))
            {
                delimiters.Add(numbersCollection[2]);
            }

            var charArray = numbersCollection.Split(delimiters.ToArray());

            int sum = 0;
            foreach (string strNumber in charArray)
            {
                int number;
                if (int.TryParse(strNumber, out number) && number <= 1000)
                {
                    if (number < 0)
                    {
                        negativeNumbers.Add(number);
                    }
                    else
                    { 
                        sum += number;
                    }
                }
            }

            if (negativeNumbers.Count > 0)
            {
                throw new Exception("Negative numbers!");
                // print out all negatives
            }

            return sum;
        }
    }
}
