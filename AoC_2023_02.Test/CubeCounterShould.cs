using System.Collections.Generic;
using Xunit;

namespace AoC_2023_02.Test
{
    public class CubeCounterShould
    {

        [Theory]
        [InlineData("6 red", CubeType.Red, 6)]
        [InlineData("2 green", CubeType.Green, 2)]
        [InlineData("589 blue", CubeType.Blue, 589)]

        public void InstantiateCubeFromString(string text,CubeType? expectedType, int? expectedCount)
        {
            CubeCounter? cube = CubeCounter.CubeFromString(text);
            Assert.NotNull(cube);
            Assert.Equal(cube.getType(), expectedType);
            Assert.Equal(cube.getCount(), expectedCount);
        }
        [Theory]
        [InlineData("6 reddsads")]
        [InlineData("2 ")]
        [InlineData("blue")]
        public void NotInstantiateCubeFromBadString(string text)
        {
            CubeCounter? cube = CubeCounter.CubeFromString(text);
            Assert.Null(cube);
        }
        [Theory]
        [InlineData("6 red", CubeType.Red, 6)]
        [InlineData("2 green", CubeType.Green, 2)]
        [InlineData("589 blue", CubeType.Blue, 589)]
        [InlineData("Game SomeNumber 99128: 589 blue", CubeType.Blue, 589)]
        [InlineData("Game SomeNumber 99128: , 589 blue, ", CubeType.Blue, 589)]
        public void ExtractCubeAndCountFromString(string text, CubeType expectedType, int expectedCount)
        {
            CubeCounter[] cubes = CubeCounter.CubesFromString(text);
            foreach (CubeCounter cube in cubes)
            {
                if (cube.getType() == expectedType)
                    Assert.Equal(cube.getCount(), expectedCount); 
            }

        }
        [Theory]
        [InlineData("6 red, 2 green, 589 blue", 3)]
        [InlineData("6 red,  589 blue", 3)]
        [InlineData("Game SomeNumber 99128: , 589 blue, ", 3)]
        [InlineData("Game 2: , 589 blue, 589 blue, 58 somthign 61 ", 3)]
        public void ExtractMultipleCubeCountersFromString(string text, int expected_count) 
        {
            CubeCounter[] cubes = CubeCounter.CubesFromString(text);
            Assert.Equal(cubes.Count(), expected_count);
        }
        [Theory]
        [InlineData(1, CubeType.Red, 2, CubeType.Red)]
        [InlineData(111, CubeType.Green, 899, CubeType.Green)]
        public void updateMaxCubesWhenTypesMatch(int count1, CubeType type1, int count2, CubeType type2)
        {
            CubeCounter primaryCube = new CubeCounter(type1, count1);
            CubeCounter secondaryCube = new CubeCounter(type2, count2);
            primaryCube.updateMaxIfMatchingCube(secondaryCube);
            Assert.Equal(primaryCube.getCount(), Math.Max(count1,count2));
        }
        [Theory]
        [InlineData(1, CubeType.Red, 2, CubeType.Blue)]
        [InlineData(111, CubeType.Red, 899, CubeType.Green)]
        public void notUpdateMaxCubesWhenTypesDoNotMatch(int count1, CubeType type1, int count2, CubeType type2)
        {
            CubeCounter primaryCube = new CubeCounter(type1, count1);
            CubeCounter secondaryCube = new CubeCounter(type2, count2);
            primaryCube.updateMaxIfMatchingCube(secondaryCube);
            Assert.Equal(primaryCube.getCount(), count1);
        }

    }

    public class PuzzleSolverShould
    {
        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
        public void CorrectlyEvaluateCubeLimits(string text, bool expected)
        {
            bool countFitsInLimit = PuzzleSolver.RowFitsLimit(text);
            Assert.Equal(countFitsInLimit, expected);

        }
        [Theory]
        [InlineData("TestInput1.txt",8)]
        public void CorrectlySolvePuzzle1FromFile(string filename,int expected)
        {
            //string filename = "PuzzleInput.txt";
            string directory = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\Courses\\PluralSight\\xUnit_Course\\AoC_2023_02.Test";
            string path = Path.Combine(directory, filename);
            int actual = PuzzleSolver.SolvePuzzle1FromPath(path);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("TestInput1.txt", 2286)]
        public void CorrectlySolvePuzzle2FromFile(string filename, int expected)
        {
            //string filename = "PuzzleInput.txt";
            string directory = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\Courses\\PluralSight\\xUnit_Course\\AoC_2023_02.Test";
            string path = Path.Combine(directory, filename);
            int actual = PuzzleSolver.SolvePuzzle2FromPath(path);
            Assert.Equal(expected, actual);
        }

    }
}