namespace AoC_2023_08
{
    public interface IDataAccessBuilder
    {
        IDataAccessBuilder Build();
    }
    public interface IDataAccess
    {
        public void BuildFromStrings(IEnumerable<string> list);
        public Tuple<string, string>? Get(string key);
        public void Set(string key, Tuple<string, string> value);
        public void SetWalkPath(string target);
        public string GetWalkPath();
        internal IEnumerable<string> GetAllKeys();
    }
    public interface IDataTraverser
    {
        public Tuple<string, string>? Get(string key);
        public void Set(string key, Tuple<string, string> value);
        public double? Search(string start);
        public IEnumerable<double?> SearchStep();
    }
    public interface IDataTraverserBuilder
    {
        public IDataTraverser Build();
        public void SetTarget(string target);
        public void SetWalkPath(string walkPath);
        public void SetData(IDataAccess data);
    }
    public interface IPrimeFactor
    {
        public static abstract List<double> GetPrimeFactors(double number);
    }
}
