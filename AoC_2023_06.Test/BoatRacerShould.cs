using System.Collections;
using System.Linq;
namespace AoC_2023_06.Test
{
    class PathCounterVarietyData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var outputs = new List<object[]>
                {
                new object[] { new NaiveCounter(), 7, 9, 4 },
                new object[] { new NaiveCounter(), 15, 40, 8 },
                new object[] { new NaiveCounter(), 30, 200, 9 },
                new object[] { new MathematicalCounter(), 7, 9, 4 },
                new object[] { new MathematicalCounter(), 15, 40, 8 },
                new object[] { new MathematicalCounter(), 30, 200, 9 },
                };
            foreach (object[] output in outputs){
                yield return output;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class SolverVariety : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var outputs = new List<object[]>
                {
                new object[] {new BoatRacer(new NaiveCounter(), new BasicReader()) },
                new object[] { new BoatRacer(new MathematicalCounter(), new BasicReader()) }
                };
            foreach (object[] output in outputs)
            {
                yield return output;
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class BoatRacerImplementationsShould
    {
        readonly string filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_06.Test\\TestData1.txt";

        [Fact]
        public void ReadFilesCorrectly()
        {
            var reader = new BasicReader();
            var data = reader.ReadFile(filePath);
            List<(long, long)> expectedPairs = [(7, 9), (15, 40), (30, 200)];
            Assert.Equivalent(data, expectedPairs);
        }

        [Theory]
        [InlineData("test:    1   2  12", 24)]
        [InlineData("tesasd sadasd  1 dasdas  2 asdsad  12 saddasa23123adsads", 24)]
        public void ParseRowsCorrectly(string row, long expectedProduct)
        {
            var output = BasicReader.ProcessRow(row);
            var outputSum = output.Aggregate((agg,x) => agg*x);
            Assert.Equal(expectedProduct, outputSum);
        }

        [Theory]
        [ClassData(typeof(PathCounterVarietyData))]
        public void CorrectlyCountNumberOfPathsToVictory(IPathCounter counter, long time, long distance, long expectedCount)
        {
            long actualCount = counter.Count(time, distance);
            Assert.Equal(expectedCount, actualCount);
        }
        [Theory]
        [ClassData(typeof(SolverVariety))]
        public void SolvesTestCaseCorrectly(BoatRacer solver)
        {   
            var solution = solver.SolvePuzzle(filePath);
            long expected = 288;
            Assert.Equal(expected, solution);
        }

    }

    public class BoatRacerPart2ImplementationShould
    {
        readonly string filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_06.Test\\TestData1.txt";
        [Fact]
        public void GetExpectedResultsFromTestData()
        {
            var solver = new BoatRacer(new MathematicalCounter(), new Part2Reader());
            var solution = solver.SolvePuzzle(filePath);
            long expected = 71503;
            Assert.Equal(expected, solution);
        }
    }
}