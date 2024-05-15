using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_05.Test
{
    public class GroupManagerShould
    {
        readonly string filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_05.Test\\TestInput.txt";
        [Fact]
        public void ReadDataFromFile()
        {
            GroupManager _ = new(filePath);
        }
        [Fact]
        public void ThrowIfFileDoesNotExist()
        {
            _ = Assert.Throws<FileNotFoundException>(() => new GroupManager("sad213"));
        }
        [Theory]
        [InlineData(79, 82, "TestInput")]
        [InlineData(14, 43, "TestInput")]
        [InlineData(55, 86, "TestInput")]
        [InlineData(13, 35, "TestInput")]
        [InlineData(79, 81, "TestInput_Minimal")]
        [InlineData(14, 14, "TestInput_Minimal")]
        [InlineData(55, 57, "TestInput_Minimal")]
        [InlineData(13, 13, "TestInput_Minimal")]
        [InlineData(55, 42, "TestInput_Small")]
        [InlineData(79, 66, "TestInput_Small")]

        public void CorrectlySolveTestCaseComponents(long seed, long expected, string fileName)
        {
            string filePath = $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_05.Test\\{fileName}.txt";
            GroupManager groupManager = new GroupManager(filePath);
            Assert.Equal(expected, groupManager.ProcessSeed(seed));

        }
        [Fact]
        public void CorrectlySolveTestCase()
        {
            GroupManager groupManager = new GroupManager(filePath);
            Assert.Equal(35, groupManager.GetSmallestOutputSeed());

        }
        [Theory]
        [InlineData(1, 79, 81)]
        [InlineData(2, 79, 81)]
        [InlineData(3, 79, 81)]
        [InlineData(4, 79, 74)]
        [InlineData(5, 79, 78)]
        [InlineData(6, 79, 78)]
        [InlineData(7, 79, 82)]

        [InlineData(1, 14, 14)]
        [InlineData(2, 14, 53)]
        [InlineData(3, 14, 49)]
        [InlineData(4, 14, 42)]
        [InlineData(5, 14, 42)]
        [InlineData(6, 14, 43)]
        [InlineData(7, 14, 43)]

        public void SolvesNStepsCorrectly(long nsteps, long seed, long expected)
        {   
            GroupManager groupManager = new(filePath);
            long currentValue = seed;
            for (long i = 0; i < nsteps; i++)
            {
                MapGroup map = groupManager.groups[i];
                currentValue = map.ApplyMapping(currentValue);
            }
            Assert.Equal(expected, currentValue);
        }

        [Fact]
        public void HaveMapGroupsInTheCorrectOrder()
        {
            GroupManager groupManager = new(filePath);
            string[] names = groupManager.groups.Select(group => group.name).ToArray();
            string[] expectedNames = ["seed-to-soil", "soil-to-fertilizer", "fertilizer-to-water", "water-to-light", "light-to-temperature", "temperature-to-humidity", "humidity-to-location"];
            Assert.Equal(expectedNames, names);
        }
    }
    public class CondencedMapShould
    {
        readonly string filePath = $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_05.Test\\TestInput.txt";
        [Theory]
        [InlineData(79, 82, "TestInput")]
        [InlineData(55, 86, "TestInput")]
        [InlineData(79, 81, "TestInput_Minimal")]
        [InlineData(55, 57, "TestInput_Minimal")]
        [InlineData(55, 42, "TestInput_Small")]
        [InlineData(79, 66, "TestInput_Small")]
        [InlineData( 1, 8, "TestInput_Trivial")]

        public void CorrectlyMatchOutputs(long seed, long expected, string fileName)
        {
            string filePath = $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_05.Test\\{fileName}.txt";
            GroupManager groupManager = new(filePath);
            Assert.Equal(expected, groupManager.ProcessSeedCondenced(seed));

        }
        [Theory]
        [InlineData(79, 14)]
        //[InlineData(58, 3)]
        [InlineData(55, 13)]

        public void CorrectlyMatchProcessingOutputs(long start, long length)
        {
            GroupManager groupManager = new(filePath);
            var nums = Enumerable.Range((int)start, (int)length);
            var preCondencedOutput = nums.Select(v => groupManager.ProcessSeed(v));
            var postCondencedOutput = nums.Select(v => groupManager.ProcessSeedCondenced(v));
            Assert.Equal(preCondencedOutput, postCondencedOutput);

        }
        [Theory]
        [InlineData(1, 2, "TestInput_Trivial")]
        public void CorrectlyMatchArbitraryProcessingOutputs(long start, long length, string fileName)
        {
            string spesificFilePath = $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_05.Test\\{fileName}.txt";
            GroupManager groupManager = new(spesificFilePath);
            var nums = Enumerable.Range((int)start, (int)length);
            var preCondencedOutput = nums.Select(v => groupManager.ProcessSeed(v));
            var postCondencedOutput = nums.Select(v => groupManager.ProcessSeedCondenced(v));
            Assert.Equal(preCondencedOutput, postCondencedOutput);

        }
        [Theory]
        [InlineData(82,46)]
        public void CorrectlySolveTestCase(long seed, long expectedMinimumOutput)
        {
            GroupManager groupManager = new(filePath);
            //groupManager.UseCondencedMap();
            long output = groupManager.ProcessSeedCondenced(seed);
            Assert.Equal(expectedMinimumOutput, output);
        }
    }
}
