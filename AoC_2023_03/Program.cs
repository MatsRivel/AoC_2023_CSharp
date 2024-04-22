using AoC_2023_03;

string filename = "PuzzleInput.txt";
string directory = "C:\\Users\\mats.riveland\\OneDrive - Bouvet Norge AS\\Documents\\Courses\\PluralSight\\xUnit_Course\\AoC_2023_03";
string path = Path.Combine(directory, filename);
PuzzleSolver ps = new(path);
int output = ps.SumOfComponentsAdjacentToSymbols();
Console.WriteLine($"{output} (Correct answer: {output == 529618})");