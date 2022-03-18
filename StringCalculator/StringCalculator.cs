using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbersCollection)
        {
            var delimiters = new List<string> {",", "\n"};
            var numberSplit = Array.Empty<string>();
            string[] lines = Array.Empty<string>();

            if (numbersCollection.StartsWith("//"))
            {
                lines = numbersCollection.Split("\n");
                string delimiterString = lines[0].Substring(2, lines[0].Length - 2);
                if (numbersCollection.Contains("["))
                {
                    delimiters = GetDelimiters(delimiterString);
                }
                else
                {
                    delimiters.Add(delimiterString);
                }

                numberSplit = lines[1].Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                numberSplit = numbersCollection.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            var parsedNumbers = numberSplit.Select(x =>
            {
                int.TryParse(x, out var number);
                return number;
            });

            var negatives = parsedNumbers.Where(x => x < 0);

            if (negatives.Any())
            {
                throw new ArgumentException("Negatives not allowed! ", String.Join(", ", negatives.ToArray()));
            }

            return parsedNumbers.Where(x => x <= 1000).Sum();
        }

        private static List<string> GetDelimiters(string delimiterString)
        {
            List<string> delimiters = new List<string>();
            string newDelimiter = "";

            foreach (char c in delimiterString)
            {
                switch (c)
                {
                    case '[':
                        newDelimiter = "";
                        break;
                    case ']':
                        delimiters.Add(newDelimiter);
                        break;
                    default:
                        newDelimiter = newDelimiter + c;
                        break;
                }
            }
            return delimiters;
        }
    }
}