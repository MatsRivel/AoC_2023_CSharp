namespace AoC_2023_08
{

    public class DataAccess : IDataAccess
    {
        string walkPath;
        Dictionary<string, Tuple<string, string>> data = new();
        private static Tuple<string, string, string> StringToData(string s)
        {
            // This function assumes exactly 3 elements of exactly 3 characters in the form "AAA = (BBB, CCC)"
            string key = s.Substring(0, 3);
            string val1 = s.Substring(7, 3);
            string val2 = s.Substring(12, 3);
            return new(key, val1, val2);

        }
        public void BuildFromStrings(IEnumerable<string> list)
        {
            foreach (string s in list)
            {
                if (s.Length >= "AAA = (BBB, CCC)".Length)
                {
                    Tuple<string, string, string> elements = DataAccess.StringToData(s);
                    string key = elements.Item1;
                    string val1 = elements.Item2;
                    string val2 = elements.Item3;
                    this.Set(key, new(val1, val2));
                }
                else if (s.Length > 0)
                {
                    walkPath = s;
                }
            }
        }

        public Tuple<string, string>? Get(string key)
        {
            try
            {
                return this.data[key];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public string GetWalkPath() { return walkPath; }

        public void Set(string key, Tuple<string, string> value) { this.data[key] = value; }

        public void SetWalkPath(string walkPath) { this.walkPath = walkPath; }

        IEnumerable<string> IDataAccess.GetAllKeys() { return [.. this.data.Keys]; }
    }
}
