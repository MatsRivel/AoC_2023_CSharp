using System;

namespace AoC_2023_05.Test
{
    public class MappingShould
    {
        [Theory]
        [InlineData(49,53,8)]
        [InlineData(0,11,42)]
        [InlineData(42,0,7)]
        [InlineData(57,7,4)]
        [InlineData(1, 10, 8)]
        public void BuildAsExpected(long destination, long source, long range)
        {
            string row = $"{destination} {source} {range}";
            Mapping rowMapping = new(row);
            Mapping directMapping = new(destination, source, range);
            Assert.Equal(rowMapping.destination, directMapping.destination);
            Assert.Equal(rowMapping.source, directMapping.source);
            Assert.Equal(rowMapping.length, directMapping.length);
        }
        [Fact]
        public void IsNotAllwaysZero()
        {
            string row = "1 10 8";
            Mapping rowMapping = new(row);
            Assert.NotEqual(0, rowMapping.destination);
            Assert.NotEqual(0, rowMapping.source);
            Assert.NotEqual(0, rowMapping.length);
        }

        [Theory]
        [InlineData("1 10 8", 19, false)]
        [InlineData("1 10 8", 18, false)]
        [InlineData("1 10 8", 17, true)]
        [InlineData("1 10 8", 13, true)]
        [InlineData("1 10 8", 10, true)]
        [InlineData("1 10 8",  9, false)]

        public void MaContainsAsExpected(string row, long sourceValue, bool expectedOutput)
        {
            Mapping rowMapping = new(row);
            Assert.Equal(rowMapping.Contains(sourceValue), expectedOutput);
        }

        [Theory]
        [InlineData("1 10 8", 19, null)]
        [InlineData("1 10 8", 18, null)]
        [InlineData("1 10 8", 17, (long)8)]
        [InlineData("1 10 8", 13, (long)4)]
        [InlineData("1 10 8", 10, (long)1)]
        [InlineData("1 10 8",  9, null)]


        public void MapAsExpected(string row, long sourceValue, long? expectedOutput)
        {
            Mapping rowMapping = new(row);
            Assert.Equal(expectedOutput, rowMapping.TryMap(sourceValue));
        }
    }
}