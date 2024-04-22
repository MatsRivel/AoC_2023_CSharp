using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AoC_2023_02
{
    public enum CubeType
    {
        Red,
        Green,
        Blue
    }
    public class CubeCounter(CubeType type, int count)
    {
        private readonly CubeType type = type;
        private int count = count;

        private static CubeType? TypeFromString(string text)
        {
            switch (text)
            {
                case "red":
                    return CubeType.Red;
                case "green":
                    return CubeType.Green;
                case "blue":
                    return CubeType.Blue;
                default:
                    return null;
            }
        }
        private static string[]? MatchRegexForCubeInformation(string text)
        {
            string pattern = "\\d+\\s{1}(red|blue|green)";
            Regex rg = new Regex(pattern);
            MatchCollection matches = rg.Matches(text);
            string[]? matchingStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();
            return matchingStrings;
        } 
        private static string[]? GetCleanStrings(string text)
        {
            return MatchRegexForCubeInformation(text);
        }

        public static CubeCounter? CubeFromString(string text)
        {
            string[] cubeComponentStrings = text.Split(' ');
            if (cubeComponentStrings.Length != 2)
            {
                return null;
            }
            string count_string = cubeComponentStrings[0];
            string type_string = cubeComponentStrings[1];
            int? count = int.Parse(count_string);
            CubeType? type = TypeFromString(type_string);
            if (count is null || type is null)
            {
                return null;
            }
            CubeCounter newCube = new CubeCounter((CubeType)type, (int)count);
            return newCube;
        }
        public static CubeCounter[] CubesFromString(string text)
        {
            string[]? cleanStrings = GetCleanStrings(text);
            if (cleanStrings is null)
            {
                return [];
            }
            CubeCounter Red = new(CubeType.Red, 0);
            CubeCounter Green = new(CubeType.Green, 0);
            CubeCounter Blue = new(CubeType.Blue, 0);
            CubeCounter[] AllCubes = [Red, Green, Blue];

            foreach (string segment in cleanStrings)
            {
                CubeCounter? newCubeCandidate = CubeFromString(segment);
                if (newCubeCandidate is null)
                {
                    continue;
                }
                CubeCounter newCube = (CubeCounter) newCubeCandidate;
                foreach (CubeCounter primaryCube in AllCubes)
                {
                    primaryCube.updateMaxIfMatchingCube(newCube);
                }
            }

            return AllCubes;
        }


        public CubeType getType()
        {
            return this.type;
        }
        public int getCount()
        {
            return this.count;
        }

        private bool sameTypeAs(CubeCounter other)
    {
        return (this.type == other.type);
    }
    public void updateMaxIfMatchingCube(CubeCounter other)
        {
            if (this.sameTypeAs(other))
            {
                this.count = Math.Max(this.count, other.count);
            }
        }
    }

    public class PuzzleSolver
    {
        public static bool RowFitsLimit(string text)
        {
            int[] limits = [12, 13, 14];
            CubeCounter[] cubeList = CubeCounter.CubesFromString(text);
            foreach ((int limit, CubeCounter cube) in limits.Zip(cubeList)){
                if (limit < cube.getCount())
                {
                    return false;
                }
            }
            return true;
        }
        public static int SolvePuzzle1FromPath(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path);
            }
            catch
            {
                string exception_text = $"Failed to read file: {path}";
                throw new Exception(exception_text);
            }
            return SolvePuzzle1FromLines(lines);
        }
        public static int SolvePuzzle1FromLines(string[] lines)
        {
            int output = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (RowFitsLimit(line))
                {
                    output += i + 1;
                }
            }
            return output;
        }
        public static int SolvePuzzle2FromPath(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path);
            }
            catch
            {
                string exception_text = $"Failed to read file: {path}";
                throw new Exception(exception_text);
            }
            return SolvePuzzle2FromLines(lines);
        }
        public static int SolvePuzzle2FromLines(string[] lines)
        {
            int output = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                CubeCounter[] newCubes = CubeCounter.CubesFromString(line);
                int cubeProd = newCubes[0].getCount();
                for (int j = 1; j < newCubes.Length; j++)
                {
                    cubeProd *= newCubes[j].getCount();
                }
                output += cubeProd;
            }
            return output;
        }

    }
}
