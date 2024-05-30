using AoC_2023_08;
using static System.Runtime.InteropServices.JavaScript.JSType;

var filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\Deleteme\\PuzzleInput.txt";
//filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_08.Test\\TestInput1.txt";
//filePath = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\CodeStuff\\AoC_2023_CSharp\\AoC_2023_08.Test\\TestInput2.txt";
DataAccess dataAccess = new();
DataTraverserBuilder dataTraverserBuilder = new();
double? output = PuzzleSolver.Solve(filePath, dataAccess, dataTraverserBuilder);
double expected = 20569;
Console.WriteLine($"Got {output}, expected {expected}");
if (output == expected)
{
    Console.WriteLine("Success!");
}
else
{
    Console.WriteLine("Failed!");
}

dataAccess = new();
dataTraverserBuilder = new();
output = PuzzleSolver.SolveP2(filePath, dataAccess, dataTraverserBuilder);
expected = -1;
Console.WriteLine($"Got {output}, expected {expected}");
if (output == expected)
{
    Console.WriteLine("Success!");
}
else
{
    Console.WriteLine("Failed!");
}
