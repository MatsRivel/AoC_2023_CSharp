using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_04
{

    /*
     * Scratch Manager should hold a counter of how many times we get identical copies of each card.
     * So if Card 1 (C1) wins on 2, we get both C2 and C3. Then C2 wins 5, so we get C3 through C7.
     * This means we should now have 
     */
    public class ScratchManager
    {
        public List<Card> cards;
        public ScratchManager(string filePath) {
            ScratchCard scratch = new ScratchCard(filePath);
            cards = scratch.cards;
        }
        public int CalculateFinalNumberOfCards()
        {
            List<int[]> counts = cards.Select(card => new int[]{1, card.GetMatchingNumbers().Length}).ToList();

            for (int i = 0; i < counts.Count; i++)
            {
                int nCopiesOfCurrentCard = counts[i][0];
                int nNewCards = counts[i][1];
                for (int j = i+1; j < counts.Count && j <= i+nNewCards; j++)
                {
                    counts[j][0] += nCopiesOfCurrentCard;
                }
            }
            int score = counts.Aggregate(0, (agg, val) => agg + val[0]);
            return score;
        }
    }
}
