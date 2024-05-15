namespace AoC_2023_04.Test
{
    public class ScratchCardShould
    {
        public static string AddFileNameToDirPath(string fileName)
        {
            return $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_04.Test\\{fileName}";
        }

        [Fact]
        public void CreateSingleCardFromSingleRowFile()
        {
            string fileName = "TestInput_Minimal.txt";
            string filePath = AddFileNameToDirPath(fileName);
            ScratchCard scratch = new(filePath);
            Assert.Single(scratch.cards);
            Card card = scratch.cards.First();
            Assert.Equal(2, card.cardNumber);
            Assert.Equal(13, card.winningNumbers[0]);
            Assert.Equal(61, card.winningNumbers.Last());
            Assert.Equal(61, card.ownedNumbers[0]);
            Assert.Equal(19, card.ownedNumbers.Last());
            
        }
        [Fact]
        public void ThrowWhenNotFindingFile(){
            ScratchCard scratch;

            _ = Assert.Throws<FileNotFoundException>(() => scratch = new("123213asd2"));
        }
        [Theory]
        [InlineData("TestInput_Minimal.txt",2)]
        [InlineData("TestInput_Small.txt", 2)]
        [InlineData("TestInput.txt", 13)]
        public void GetCorrectScoreTotal(string fileName, int expectedScore)
        {
            string filePath = AddFileNameToDirPath(fileName);
            ScratchCard scratch = new(filePath);
            Assert.Equal(expectedScore, scratch.CalculateScore());

        }

    }
}