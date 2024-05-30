using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_08
{
    public class PuzzleSolver
    {

        private static IDataAccess BuildData(string filePath, IDataAccess DataStorage)
        {
            var lines = File.ReadLines(filePath);
            DataStorage.SetWalkPath(lines.First());
            DataStorage.BuildFromStrings(lines);
            return DataStorage;

        }
        public static double? Solve(string filePath, IDataAccess dataStorage, IDataTraverserBuilder dataTraverserBuilder)
        {
            var updatedDataStorage = PuzzleSolver.BuildData(filePath, dataStorage);
            var walkPath = updatedDataStorage.GetWalkPath();
            dataTraverserBuilder.SetWalkPath(walkPath);
            dataTraverserBuilder.SetTarget("ZZZ"); // TODO: Currently hardcoded. probably not best idea.
            dataTraverserBuilder.SetData(updatedDataStorage);
            IDataTraverser DataTraverser = dataTraverserBuilder.Build();

            return DataTraverser.Search("AAA");
        }

        private static IEnumerable<string> FindStartPoints(IDataAccess dataStorage)
        {
            var keys = dataStorage.GetAllKeys().Where(x => x.Last() == 'A');
            keys = keys.ToImmutableSortedSet().Reverse();
            Console.WriteLine($"{keys.First()}, {keys.Last()}");
            return keys;
        }


        public static double? SolveP2(string filePath, IDataAccess dataStorage, IDataTraverserBuilder dataTraverserBuilder)
        {
            var updatedDataStorage = PuzzleSolver.BuildData(filePath, dataStorage);
            var walkPath = updatedDataStorage.GetWalkPath();
            var startingPoints = FindStartPoints(dataStorage);
            dataTraverserBuilder.SetWalkPath(walkPath);
            dataTraverserBuilder.SetTarget("ZZZ"); // TODO: Currently hardcoded. probably not best idea.
            dataTraverserBuilder.SetData(updatedDataStorage);
            IDataTraverser DataTraverser = dataTraverserBuilder.Build();
            var allPrimes = new List<double>();
            foreach (string start in startingPoints)
            {
                if (start == "STA") // TODO: Remove. Temporary check.
                {
                    continue;
                }
                Console.Write($"Starting at: {start}");
                var pathLength = DataTraverser.Search(start);
                var loopLength = DataTraverser.Search("ZZZ");
                var totalLength = pathLength + loopLength;
                Console.WriteLine($", pathLength: {pathLength}, loopLength: {loopLength}, totalLength: {totalLength}");
                foreach (double prime in PrimeFactorSolver.GetPrimeFactors((double)totalLength))
                {
                    if (!allPrimes.Contains(prime)) { allPrimes.Add(prime); }
                }
            }
            var output = allPrimes.Aggregate((double)1, (agg, val) => agg * val);
            return output;
        }
    }
}
