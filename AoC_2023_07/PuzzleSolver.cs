using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_07
{
    public class PuzzleSolver
    {
        public static List<HandInfo> RankCards(List<string> cardStrings)
        {
            throw new NotImplementedException();
        }
        public static List<HandInfo> ReadFile(string filePath)
        {   
            var lines = File
                .ReadAllLines(filePath)
                .Select(line => ProcessRow(line))
                .ToList();
            return lines;
        }
        public static HandInfo ProcessRow(string row)
        {
            var splitRow = row
                .Split(' ')
                .ToList();
            var output = new HandInfo(splitRow[0], int.Parse(splitRow[1])); // Fallable, but with correct formatted input it should work.
            return output;
        }
        internal static bool IsNumeric(string s) => ParseIntOrNull(s) != null;
        internal static int? ParseIntOrNull(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
