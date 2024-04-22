using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_04
{
    public class ScratchCard
    {
        public List<Card> cards;
        public List<string> ReadCardsFromFile(string path)
        {
            List<string> lines;
           lines = File.ReadAllLines(path).ToList();

            return lines;
        }

        public int CalculateScore()
        {
            int score = cards
                .Select(card => card.CardScore())
                .Aggregate(0, (accumulator, value) => accumulator + value);
            return score;
        }

        public ScratchCard() {
            cards = new List<Card>();
        }

        public ScratchCard(string path)
        {
            List<string> rows = ReadCardsFromFile(path);
            cards = rows.Select(row => new Card(row)).ToList();
        }
    }
}
