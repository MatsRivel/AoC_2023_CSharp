using System.Runtime.CompilerServices;

namespace AoC_2023_07.Test
{
    public class CardsShould
    {
        readonly string filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_07.Test\\TestData.txt";
        [Fact]
        public void ReadFileCorrectly()
        {
            var expectedHandsAndBets= new List<(string,int)>() {
                ("32T3K",765),
                ("T55J5",684),
                ("KK677",28),
                ("KTJJT",220),
                ("QQQJA",483),
            };
            var actualHandsAndBets= Cards.ReadFile(filePath);
        }

        [Fact]
        public void RanksCardsCorrectly()
        {
            var cardStrings = new List<string>() { "32T3K", "T55J5", "KK677", "KTJJT", "QQQJA" };
            Dictionary<string, int> expectedCardRanls= new Dictionary<string, int>() {
                {"32T3K", 1},
                {"KTJJT", 2},
                {"KK677", 3},
                {"T55J5", 4},
                {"QQQJA", 5}
            };
            List<(string,int)> rankedCards = Cards.Rankcards(cardStrings);
            foreach ((string card, int rank) in rankedCards)
            {
                Assert.Equal(expectedCardRanls[card], rank);

            }
        }
    }
}                                                          