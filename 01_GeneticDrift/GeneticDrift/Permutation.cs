using System.Text;
using System.Xml.XPath;

namespace GeneticDrift;

public class Permutation
{
    public int Length { get; }
    public int[] Numbers { get; private set; }
    public int[] Info { get; }

    public Permutation(string input)
    {
        string[] parts = input.Split(' ');

        Length = Convert.ToInt32(parts[0]);

        int[] numbers = new int[parts.Length + 1];

        for (int i = 1; i < parts.Length; i++)
        {
            numbers[i - 1] = Convert.ToInt32(parts[i]);
        }
        int[] info = new int[4];

        for (int i = Length + 1; i < parts.Length; i++)
        {
            info[i - 1 - Length] = Convert.ToInt32(parts[i]);
        }

        Numbers = numbers;
        Info = info;
    }

    public string Level1()
    {
        List<Pair> pairs = GetPairs(Numbers);

        string output = Convert.ToString(pairs.Count);

        foreach (var pair in pairs)
        {
            output += $" {pair}";
        }

        return output;
    }
    public string Level2()
    {
        int [] lvl2Result = Inverse(Info[0], Info[1], Info[2], Info[3]);
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var number in lvl2Result) stringBuilder.Append($"{number} ");
        return stringBuilder.ToString();
    }
    public string Level3()
    {
        int[] inverse = Inverse(Info[0], Info[1], Info[2], Info[3]);
        return Convert.ToString(GetPairs(inverse).Count);

    }
    private int[] Inverse(int x, int i, int y, int j)
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

        for (int k = start; k <= end; k++)
        {
            Numbers[k] = inverse[count];
            count++;
        }
        return Numbers.Skip(0).ToArray().SkipLast(6).ToArray();
    }

    private List<Pair> GetPairs(int[] input)
    {
        int count = 0;
        List<Pair> pairs = new List<Pair>();

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j < input.Length; j++)
            {
                if (input[i] == 0 && input[j] > 0 || input[i] > 0 && input[j] == 0)
                {
                    continue;
                }

                int value = input[i] * -1 - input[j];
                value = Math.Abs(value);

                if (value == 1)
                {
                    count++;
                    Pair pair = new Pair(input[i], input[j], i, j);
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