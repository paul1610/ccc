namespace GeneticDrift;

public class Permutation
{
    public int Length { get; }
    public int[] Numbers { get; }

    public Permutation(string input)
    {
        string[] parts = input.Split(' ');

        Length = Convert.ToInt32(parts[0]);

        int[] numbers = new int[parts.Length - 1];

        for (int i = 1; i < parts.Length; i++)
        {
            numbers[i - 1] = Convert.ToInt32(parts[i]);
        }

        Numbers = numbers;
    }

    public string Level1()
    {
        List<Pair> pairs = GetPairs();

        string output = Convert.ToString(pairs.Count);

        foreach (var pair in pairs)
        {
            output += $" {pair}";
        }

        return output;
    }
    public string Level2()
    {
        List<Pair> pairs = GetPairs();
        string output = "";
        List<int> result = Numbers.ToList();
        foreach (var pair in pairs)
        {
            if(pair.X + pair.Y == 1)
            {
                InvertList(pair.XIndex, pair.YIndex - 1);
            }
            else if(pair.X + pair.Y == -1)
            {
                InvertList(pair.XIndex + 1, pair.YIndex);
            }
        }
        return output;
        void InvertList(int from, int to)
        {
            int[] valsToInvert = new int[to - from];
            
        }
    }
    private List<Pair> GetPairs()
    {
        int count = 0;
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
                    count++;
                    Pair pair = new Pair(Numbers[i], Numbers[j], i, j);
                    pairs.Add(pair);
                }
            }
        }
        pairs.Sort();
        return pairs;
    }

    public override string ToString()
    {
        string output = Length.ToString();

        foreach (var number in Numbers)
        {
            output += $" {number}";
        }

        return output;
    }
}