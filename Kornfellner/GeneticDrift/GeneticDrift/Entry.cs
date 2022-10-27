namespace GeneticDrift;

public class Entry
{
    public int Value { get; }
    public int Index { get; }

    public Entry(int value, int index)
    {
        Value = value;
        Index = index;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}