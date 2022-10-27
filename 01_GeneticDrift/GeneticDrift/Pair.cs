namespace GeneticDrift
{
    public class Pair : IComparable<Pair>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XIndex { get; set; }
        public int YIndex { get; set; }

        public Pair(int x, int y, int xIndex, int yIndex)
        {
            X = x;
            Y = y;
            XIndex = xIndex;
            YIndex = yIndex;
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