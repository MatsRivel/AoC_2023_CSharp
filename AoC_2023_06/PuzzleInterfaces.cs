using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_06
{
    public interface IPuzzleSolver
    {
        long SolvePuzzle(string filePath);
    }
    public interface IPathCounter
    {
        long Count(long time, long distance);
    }
    public interface IFileReader
    {
        List<(long, long)> ReadFile(string filePath);
    }

}
