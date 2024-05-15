using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_04.Test
{
    public class ScratchManagerShould
    {
        public static string AddFileNameToDirPath(string fileName)
        {
            return $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_04.Test\\{fileName}";
        }

        [Fact]
        public void ThrowWhenNotFindingFile()
        {
            ScratchCard scratch;
            _ = Assert.Throws<FileNotFoundException>(() => scratch = new("123213asd2"));
        }

        [Theory]
        [InlineData("TestInput_Minimal.txt", 1)]
        [InlineData("TestInput_Small.txt", 3)]
        [InlineData("TestInput_AllLoss.txt", 6)]
        [InlineData("TestInput.txt", 6)]
        public void HaveTheCorrectNumberOfInitialCards(string fileName, int expectedCount)
        {
            string filePath = AddFileNameToDirPath(fileName);
            ScratchManager manager = new(filePath);
            Assert.Equal(expectedCount, manager.cards.Count);

        }
        [Theory]
        [InlineData("TestInput_Minimal.txt", 1)]
        [InlineData("TestInput_Small.txt", 5)]
        [InlineData("TestInput_AllLoss.txt", 6)]
        [InlineData("TestInput.txt", 30)]
        public void HaveTheCorrectNumberOfFinalCards(string fileName, int expectedCount)
        {
            string filePath = AddFileNameToDirPath(fileName);
            ScratchManager manager = new(filePath);
            Assert.Equal(expectedCount, manager.CalculateFinalNumberOfCards());

        }
    }
}
