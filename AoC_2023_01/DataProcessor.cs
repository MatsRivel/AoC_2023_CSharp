using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_01
{
    public class DataProcessor
    {
        public static int? CheckIfNumericWord(string text)
        {
            string[] numbers = new string[10] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            for (int i = 0; i < 10; i++)
            {
                string number = numbers[i];
                if (text.StartsWith(number))
                {
                    return i;
                }
            }
            return null;
        }
        static int GetFirstDigit(string text, bool allowWords)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsDigit(c))
                {
                    return (int)char.GetNumericValue(c);
                }
                if (allowWords)
                {
                    string substring = text.Substring(i, Math.Min(5, text.Length - i));
                    int? word_numeric = CheckIfNumericWord(substring);
                    if (word_numeric is int)
                    {
                        return (int)word_numeric;
                    }
                }
            }
            string exceptionText = $"Failed to find any numbers  from the beginning of the string \"{text}\" :(";
            throw new Exception(exceptionText);

        }

        public static int LineToNum(string text, bool allowWords)
        {
            int firstDigit = GetFirstDigit(text, allowWords);
            int lastDigit = GetLastDigit(text, allowWords);
            return (firstDigit * 10) + lastDigit;
        }

        static int GetLastDigit(string text, bool allowWords)
        {
            for (int i = text.Length - 1; i >= 0; i--)
            {
                char c = text[i];
                if (char.IsDigit(c))
                {
                    return (int)char.GetNumericValue(c);
                }
                if (allowWords)
                {
                    string substring = text.Substring(i, Math.Min(5, text.Length - i));
                    int? word_numeric = CheckIfNumericWord(substring);
                    if (word_numeric is int)
                    {
                        return (int)word_numeric;
                    }
                }
            }
            string exceptionText = $"Failed to find any numbers from the end of the string \"{text}\" :(";
            throw new Exception(exceptionText);

        }

        public static int DigitSumFromFile(string path, bool allowWords)
        {
            List<string> lines;
            try
            {
                lines = File.ReadAllLines(path).ToList();
            }
            catch
            {
                string exception_text = $"Failed to read file: {path}";
                throw new Exception(exception_text);
            }

            List<int> numbers = new List<int>();
            foreach (string line in lines)
            {
                try
                {
                    int number = DataProcessor.LineToNum(line, allowWords);
                    numbers.Add(number);
                }
                catch
                {

                }
            }
            return numbers.Sum();
        }
    }
}
