using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "PuzzleInput.txt";
            string filePath = $"C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_04\\{fileName}";
            ScratchCard scratch = new(filePath);
            Console.WriteLine($"Result from p1: {scratch.CalculateScore()}");
        }
    }
}
