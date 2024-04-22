namespace AoC_2023_04.Test
{
    public class CardShould
    {
        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1, 41, 17, 83, 53)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2, 13, 61, 61, 19)]
        [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 6, 31, 72, 74, 11)]

        public void BeBuiltCorrectlyFromRow(string row, int cardNumber, int winFirst, int winLast, int ownedFirst, int ownedLast)
        {   
            Card card = new(row);
            Assert.Equal(cardNumber,card.cardNumber);
            Assert.Equal(winFirst,  card.winningNumbers.First() );
            Assert.Equal(winLast,   card.winningNumbers.Last()  );
            Assert.Equal(ownedFirst,card.ownedNumbers.First()   );
            Assert.Equal(ownedLast, card.ownedNumbers.Last()    );
        }

        [Fact]
        public void FindExistingWinningNumbersInOwnedNumbers()
        {
            string row = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";
            Card card = new(row);
            int[] winnings = card.GetMatchingNumbers();
            int[] expected = [32, 61];
            Assert.Equivalent(expected, winnings);
        }

        [Theory]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
        [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
        public void ReturnCorrectCardScore(string row, int expected)
        {
            Card card = new(row);
            Assert.Equal(expected, card.CardScore());
        }
    }
}