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
                    Pair pair = new Pair(Numbers[i], Numbers[j]);
                    pairs.Add(pair);
                }
            }
        }

        pairs.Sort();

        string output = count.ToString();

        foreach (var pair in pairs)
        {
            output += $" {pair}";
        }

        return output;
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