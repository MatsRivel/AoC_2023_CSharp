
namespace AoC_2023_08
{
    public class DataTraverser : IDataTraverser
    {
        string target;
        string walkPath;
        IDataAccess data;
        string current;
        public DataTraverser(IDataAccess data, string walkPath, string target)
        {
            this.data = data;
            this.walkPath = walkPath;
            this.target = target;
        }
        public Tuple<string, string>? Get(string key) { return data.Get(key); }

        public void Set(string key, Tuple<string, string> value) { data.Set(key, value); }

        public double? Search(string start)
        {
            this.current = start;
            var steps = SearchStep().GetEnumerator();
            while (true)
            {
                var current = steps.Current;
                if (current is null) { steps.MoveNext(); }
                else { return current; }
            }
        }

        public IEnumerable<double?> SearchStep()
        {
            double stepCount = 0;
            double walkCycleLength = (double)walkPath.Length;
            while (true)
            {
                var idx = stepCount % walkCycleLength;
                char instruction;
                try
                {
                    instruction = walkPath[(int)(stepCount % walkPath.Length)];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new Exception($"{e}\n---{walkCycleLength}, {idx}, {stepCount}");
                }
                stepCount += 1;
                // We know "AAA" allways exists as an entry point, so it should not be possible to fail the deference below.
                current = instruction switch
                {
                    'L' => this.Get(current).Item1,
                    'R' => this.Get(current).Item2,
                    _ => null
                };

                if (current == null) { yield return null; yield break; }
                else if (current == target) { yield return stepCount; }
                else { yield return null; }
            }
        }
    }
}
