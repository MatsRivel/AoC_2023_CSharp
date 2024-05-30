using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_07
{
    public class Cards
    {
        public static List<(string, int)> Rankcards(List<string> cardStrings)
        {
            throw new NotImplementedException();
        }
        public static List<(string,int)> ReadFile(string filePath)
        {   
            var lines = File
                .ReadAllLines(filePath)
                .Select(line => ProcessRow(line))
                .ToList();
            return lines;
        }
        public static (string,int) ProcessRow(string row)
        {
            var splitRow = row
                .Split(' ')
                .ToList();
            var output = (splitRow[0], (int)ParseIntOrNull(splitRow[1]));
            
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
