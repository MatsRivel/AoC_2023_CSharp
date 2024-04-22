using System.Text.RegularExpressions;

namespace AoC_2023_03
{
    public class ComponentManager
    {
        public Dictionary<Tuple<int, int>, Component> dict;
        public ComponentManager(string filePath)
        {
            dict = ReadFileToDictionary(filePath);
            
        }

        internal static Dictionary<Tuple<int, int>, Component> ReadFileToDictionary(string filePath)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch
            {
                string exception_text = $"Failed to read file: {filePath}";
                throw new Exception(exception_text);
            }

            Dictionary<Tuple<int, int>, Component> dict = [];
            string pattern = "\\d+|[^.]";
            Regex rg = new(pattern);
            int idientifierCounter = 0;
            for (int lineIdx = 0; lineIdx < lines.Length; lineIdx++)
            {
                string line = lines[lineIdx];
                MatchCollection matches = rg.Matches(line);
                foreach (Match currentMatch in matches)
                {
                    Component newComponent = new(currentMatch.Value, idientifierCounter, currentMatch.Index);
                    idientifierCounter += 1;
                    for (int i = 0; i < newComponent.GetContent().Length; i++)
                    {
                        Tuple<int, int> coordTuple = new(lineIdx, currentMatch.Index + i);
                        dict.Add(coordTuple, newComponent);

                    }
                }
            }
            return dict;
        }
        public bool ContainsKey(Tuple<int, int> key)
        {
            return dict.ContainsKey(key);
        }

        public Component? Get(Tuple<int, int> key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            return null;
        }

        public void Add(Tuple<int, int> coordTuple, Component newComponent)
        {
            dict.Add(coordTuple, newComponent);
        }

        public Component[] GetDictValues()
        {
            return [.. dict.Values];

        }

        public Tuple<int, int>[] GetDictKeys()
        {
            return [.. dict.Keys];
        }

        public Component GetDictValuesUnchecked(Tuple<int, int> key)
        {
            return dict[key];
        }
    }
}
