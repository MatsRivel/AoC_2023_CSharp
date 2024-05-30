using System.Runtime.CompilerServices;

namespace AoC_2023_07.Test
{
    public class PuzzleSolverShould
    {
        readonly string filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_07.Test\\TestData.txt";
        [Fact]
        public void ReadFileCorrectly()
        {
            List<(string, int)> expectedHandsAndBets = [
                ("32T3K",765),
                ("T55J5",684),
                ("KK677",28),
                ("KTJJT",220),
                ("QQQJA",483),
            ];

            var actualHandsAndBets = PuzzleSolver.ReadFile(filePath);
            Assert.Equivalent(expectedHandsAndBets, actualHandsAndBets);
        }

        [Fact]
        public void RanksCardsCorrectly()
        {
            var cardStrings = new List<string>() { "32T3K", "T55J5", "KK677", "KTJJT", "QQQJA" };
            Dictionary<string, int> expectedCardRanls = new() {
                {"32T3K", 1},
                {"KTJJT", 2},
                {"KK677", 3},
                {"T55J5", 4},
                {"QQQJA", 5}
            };
            List<(string, int)> rankedCards = PuzzleSolver.RankCards(cardStrings)
                .Select(hand => (hand.Cards, hand.Bet))
                .ToList();

            foreach ((string card, int rank) in rankedCards)
            {
                Assert.Equal("32R3K", card);
                //Assert.Equal(expectedCardRanls[card], rank);

            }
        }
    }
}