namespace GeneticDrift;

public class Permutation
{
    public int Length { get; }
    public int[] Numbers { get; }

    public Permutation(string input)
    {
        string[] parts = input.Split(' ');

        Length = Convert.ToInt32(parts[0]);

        int[] numbers = new int[Length];

        for (int i = 1; i <= Length; i++)
        {
            numbers[i - 1] = Convert.ToInt32(parts[i]);
        }

        Numbers = numbers;
    }

    public Permutation(Permutation other)
    {
        Length = other.Length;

        Numbers = new int[Length];

        for (int i = 0; i < Length; i++)
        {
            Numbers[i] = other.Numbers[i];
        }
    }

    public List<Pair> GetPairs()
    {
        List<Pair> pairs = new List<Pair>();

        for (int i = 0; i < Numbers.Length; i++)
        {
            for (int j = i + 1; j < Numbers.Length; j++)
            {
                if (Numbers[i] == 0 && Numbers[j] > 0 || Numbers[i] > 0 && Numbers[j] == 0)
                {
                    continue;
                }

                int value = Numbers[i] * -1 - Numbers[j];
                value = Math.Abs(value);

                if (value == 1)
                {
                    Pair pair = new Pair(new Entry(Numbers[i], i), new Entry(Numbers[j], j));
                    pairs.Add(pair);
                }
            }
        }
        
        pairs.Sort();

        return pairs;
    }

    public Permutation Inverse(int x, int i, int y, int j)
    {
        int start;
        int end;

        if (x + y == 1)
        {
            start = i;
            end = j - 1;
        }
        else
        {
            start = i + 1;
            end = j;
        }

        int[] inverse = new int[end - start + 1];

        int count = 0;

        for (int k = end; k >= start; k--)
        {
            inverse[count] = Numbers[k] * -1;
            count++;
        }

        count = 0;

        Permutation other = new Permutation(this);

        for (int k = start; k <= end; k++)
        {
            other.Numbers[k] = inverse[count];
            count++;
        }

        return other;
    }

    public override string ToString()
    {
        string output = Length.ToString();

        foreach (var number in Numbers)
        {
            output += $" {number.ToString()}";
        }

        return output;
    }
}