using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_06
{
    public class BasicReader : IFileReader
    {
        public virtual List<(long, long)> ReadFile(string filePath)
        {
            List<string> dataString = File.ReadAllLines(filePath).ToList();
            List<(long, long)> output = ConvertStringsToPairs(dataString);
            return output;
        }
        internal static List<(long, long)> ConvertStringsToPairs(List<string> dataStrings)
        {
            List<List<long>> rows = dataStrings
                .Select(row => ProcessRow(row))
                .ToList();
            List<long> time = rows[0];
            List<long> distance = rows[1];
            List<(long, long)> output = time.Zip(distance, (a, b) => (a, b)).ToList();
            return output;
        }
        public static List<long> ProcessRow(string row)
        {
            List<long> rowsOfValues = row
                .Split(' ')
                .Where(text => IsNumeric(text))
                .Select(text => (long)ParseIntOrNull(text)) // We know these are all valid numbers, so casting is safe.
                .ToList();
            return rowsOfValues;
        }

        internal static bool IsNumeric(string s) => ParseIntOrNull(s) != null;
        internal static long? ParseIntOrNull(string s)
        {
            try
            {
                return long.Parse(s);
            }
            catch (FormatException)
            {
                return null;
            }
        }

    }
    
    public class Part2Reader : BasicReader
    {
        public override List<(long, long)> ReadFile(string filePath)
        {
            List<string> dataString = File.ReadAllLines(filePath).ToList();
            List<(long, long)> intermediaryList = ConvertStringsToPairs(dataString);
            var timeString = intermediaryList.Aggregate("", (agg, pair) => agg + pair.Item1);
            var distString = intermediaryList.Aggregate("", (agg, pair) => agg + pair.Item2);
               
            var time = (long)ParseIntOrNull(timeString); // We know they will exist, so casting to long is fine.
            var dist = (long)ParseIntOrNull(distString);
            var output = new List<(long, long)>{ (time, dist) };
            return output;
        }

    }
    public class NaiveCounter : IPathCounter
    {
        public long Count(long time, long distance)
        {
            long count = 0;
            for (long i = 0; i <= time; i++)
            {
                if ((time - i) * i > distance)
                {
                    count += 1;
                }
            }
            return count;
        }
    }
    public class MathematicalCounter : IPathCounter
    {
        public long Count(long time, long distance)
        {
            var x1 = (-time + Math.Sqrt(Math.Pow(time, 2) - 4 * distance)) / -2;
            var x2 = (-time - Math.Sqrt(Math.Pow(time, 2) - 4 * distance)) / -2;
            long x1Adjusted = (long)Math.Ceiling(x1 + 0.0000000001);     // Added because we need to BEAT the score, not hit it!
            long x2Adjusted = (long)Math.Floor(x2 - 0.0000000001);      // ----- || -----
            long output = x2Adjusted - x1Adjusted + 1;
            return output;
        }
    }
    public class BoatRacer : IPuzzleSolver
    {
        readonly IPathCounter counter;
        readonly IFileReader reader;
        public BoatRacer(IPathCounter counterIn, IFileReader readerIn)
        {
            counter = counterIn;
            reader = readerIn;
        }

        public long SolvePuzzle(string filePath)
        {
            var rows = reader.ReadFile(filePath);
            var pathsToVictory = rows
                .Select(pair => counter.Count(pair.Item1, pair.Item2))
                .Aggregate((agg, x) => agg * x);
            return pathsToVictory;
        }
    }

}
