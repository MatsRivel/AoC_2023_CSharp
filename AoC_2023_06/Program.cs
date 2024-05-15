using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_06\\PuzzleData.txt";

            var solver = new BoatRacer(new NaiveCounter(),new BasicReader());
            var solution = solver.SolvePuzzle(filePath);
            long expected = 3316275;
            Console.WriteLine($"Puzzle 1: Got {solution}, expected {expected}");
            if (solution == expected )
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failed!");

            }

            var solver2 = new BoatRacer(new MathematicalCounter(), new Part2Reader());
            var solution2 = solver2.SolvePuzzle(filePath);
            long expected2 = 27102791;
            Console.WriteLine($"Puzzle 2: Got {solution2}, expected {expected2}");
            if (solution2 == expected2)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failed!");

            }
        }
    }
}
