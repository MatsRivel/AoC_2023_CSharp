namespace AoC_2023_08.Test
{
    public class PuzzleSolverShould
    {
        readonly string basePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_08.Test\\";

        [Theory]
        [InlineData("TestInput1.txt", 6)]
        [InlineData("TestInput2.txt", 2)]

        public void SolveP1Correctly(string fileName, double expected)
        {
            var filePath = this.basePath + fileName;
            DataAccess dataAccess = new();
            DataTraverserBuilder dataTraverserBuilder = new();
            double? output = PuzzleSolver.Solve(filePath, dataAccess, dataTraverserBuilder);
            Assert.Equal(expected, output);

        }

        [Theory]
        [InlineData("TestInput1.txt", 6)]
        [InlineData("TestInput2.txt", 6)]
        public void SolveP2Correctly(string fileName, double expected)
        {
            var filePath = this.basePath + fileName;
            DataAccess dataAccess = new();
            DataTraverserBuilder dataTraverserBuilder = new();
            double? output = PuzzleSolver.SolveP2(filePath, dataAccess, dataTraverserBuilder);
            Assert.Equal(expected, output);
        }
        [Theory]
        [InlineData(15, 3, 5)]
        [InlineData(6, 2, 3)]
        [InlineData(10, 2, 5)]

        public void FactorizePrimesCorrectly(int number, int firstPrime, int secondPrime)
        {
            var output = PrimeFactorSolver.GetPrimeFactors(number);
            Assert.Equal(firstPrime, output[0]);
            Assert.Equal(secondPrime, output[1]);
        }
    }
}