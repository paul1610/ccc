namespace GeneticDrift
{
    public class Pair : IComparable<Pair>
    {
        public Entry X { get; }
        public Entry Y { get; }

        public Pair(Entry x, Entry y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }

        public int CompareTo(Pair? other)
        {
            if (other == null)
            {
                return 0;
            }

            if (X.Value < other.X.Value)
                return -1;
            if (X.Value == other.X.Value)
                return 0;
            return 1;
        }
    }
}