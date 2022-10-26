namespace Test
{
    public class Pair : IComparable<Pair>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pair(int x, int y)
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

            if (X < other.X)
                return -1;
            if (X == other.X)
                return 0;
            return 1;
        }
    }
}