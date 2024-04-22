using System.IO;

namespace AoC_2023_01.Test;

public class DataProcessorShould
{
    [Theory]
    [InlineData("1", 11)]
    [InlineData("123",13)]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void ReturnTheCorrectDigitsFromText(string text, int expected)
    {
        int actual = DataProcessor.LineToNum(text, false);
        Assert.Equal(expected, actual);
    }
    [Theory]
    [InlineData("trebuchet",false)]
    [InlineData("nb",false)]
    [InlineData("",false)]
    [InlineData("trebuchet",true)]
    [InlineData("nb",true)]
    [InlineData("",true)]

    public void ThrowErrorWhenNoDigitsExist(string text, bool allowWords)
    {
        DataProcessor dp = new();
        Assert.ThrowsAny<Exception>( () => DataProcessor.LineToNum(text, allowWords) );
    }
    [Theory]
    [InlineData("xtwox", 22)]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void AcceptNumbersFromWords(string text, int expected) {
        int actual = DataProcessor.LineToNum(text, true);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("zero",0)]
    [InlineData("one", 1)]
    [InlineData("two", 2)]
    [InlineData("three", 3)]
    [InlineData("four", 4)]
    [InlineData("five", 5)]
    [InlineData("six", 6)]
    [InlineData("seven", 7)]
    [InlineData("eight", 8)]
    [InlineData("nine", 9)]
    [InlineData("boooooooooooooooooo", null)]
    public void RecogniceWordsAsNumbers(string text, int? expected)
    {
        int? actual = DataProcessor.CheckIfNumericWord(text);
        Assert.Equal(expected, actual);
    }
    [Theory]
    [InlineData('a', null)]
    [InlineData(' ', null)]
    [InlineData('1', 1)]
    [InlineData('7', 7)]
    public void RecogniceCharactersAsNumbers(char c, int? expected)
    {
        int? actual = null;
        if (char.IsDigit(c)){
            actual = (int) char.GetNumericValue(c);
        }
        Assert.Equal(expected, actual);
    }
    [Theory]
    [InlineData("TestInput1.txt",false,142)]
    [InlineData("TestInput2.txt", true, 281)]
    public void GetTheCorrectOutcomeFromAFile(string filename, bool allowWords, int expected)
    {
        string directory = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\Courses\\PluralSight\\xUnit_Course\\AoC_2023_01.Test";
        string path = Path.Combine(directory, filename);
        int actual = DataProcessor.DigitSumFromFile(path, allowWords);
        Assert.Equal(expected, actual);
    }
}   