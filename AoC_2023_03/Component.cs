namespace AoC_2023_03
{
    public class Component
    {
        readonly private bool isSymbol;
        readonly private int? numericValue;
        readonly private string content;
        readonly public int identifier;
        readonly public int idx;
        public Component(string text, int id, int realIdx)
        {
            identifier = id;
            content = text;
            isSymbol = true;
            idx = realIdx;
            try
            {
                numericValue = int.Parse(text);
                isSymbol = false;
            }
            catch (FormatException)
            {
                numericValue = null;
            }
        }

        public bool CheckIsSymbol() { return isSymbol; }
        public int? GetNumericValue() { return numericValue; }
        public int GetNumericValueUnchecked() { return (int)numericValue; }
        public string GetContent() { return content; }
    }
}
