namespace GeneticDrift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "6 3 1 6 5 -2 4 1 1 -2 4";
            Permutation test = new Permutation(input);
            Console.WriteLine("Level 1:");
            Console.WriteLine(test.Level1());
            Console.WriteLine();
            Console.WriteLine("Level 2:");
            Console.WriteLine(test.Level2());
        }
    }
}