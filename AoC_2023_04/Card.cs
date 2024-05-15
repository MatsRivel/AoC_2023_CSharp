using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_2023_04
{
    public class Card
    {
        public int cardNumber;
        public List<int> winningNumbers;
        public List<int> ownedNumbers;

        public Card(string row) {
            string[] lrSegments = row.Split('|');
            string[] lhandStringRaw = lrSegments.First().Split(':');
            string cardNumberSectionString = lhandStringRaw.First();
            string cardNumberString = cardNumberSectionString.Split(' ').Last();
            string[] winningNumberStrings = lhandStringRaw.Last().Split(' ');
            string[] ownedNumberStrings = lrSegments.Last().Split(' ');

            cardNumber = int.Parse(cardNumberString);
            winningNumbers = winningNumberStrings
                .Where(numStr => numStr.Length > 0 && numStr != " ")
                .Select(int.Parse)
                .ToList();
            ownedNumbers = ownedNumberStrings
                .Where(numStr => numStr.Length > 0 && numStr != " ")
                .Select(int.Parse)
                .ToList();
        }

        public int[] GetMatchingNumbers()
        {
            int[] output = winningNumbers.Where(num => ownedNumbers.Contains(num)).ToArray();
            return output;
        }
        public int CardScore()
        {
            int score = 0;
            int matchingNumberLength = GetMatchingNumbers().Length;
            if (matchingNumberLength >= 1)
            {
                score = (int) Math.Pow(2, matchingNumberLength - 1);
            }
            return score;
        }
    }
}
