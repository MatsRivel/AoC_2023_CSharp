namespace AoC_2023_08
{
    public class DataTraverserBuilder : IDataTraverserBuilder
    {
        string? target;
        string? walkPath;
        IDataAccess? data;
        public IDataTraverser Build() // Should only be ran once class variables are filled in.
        {
            if (data != null && walkPath != null && target != null)
            {
                return new DataTraverser(data, walkPath, target);
            }
            else
            {
                throw new Exception("all class variables must be filled before using!");
            }
        }

        public void SetData(IDataAccess data) { this.data = data; }

        public void SetTarget(string target) { this.target = target; }

        public void SetWalkPath(string walkPath) { this.walkPath = walkPath; }
    }
}
