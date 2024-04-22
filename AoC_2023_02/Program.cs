using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_02
{
    internal class Program
    {
        static void Main()
        {
            string filename = "PuzzleInput.txt";
            string directory = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\Courses\\PluralSight\\xUnit_Course\\AoC_2023_02";
            string path = Path.Combine(directory, filename);
            int solution1 = PuzzleSolver.SolvePuzzle1FromPath(path);
            Console.WriteLine($"Solution1: {solution1} (Is Correct == {(solution1 == 2685)})");
            int solution2 = PuzzleSolver.SolvePuzzle2FromPath(path);
            Console.WriteLine($"Solution2: {solution2} (Is Correct == {(solution2 == 83707)})");

        }
    }
}
