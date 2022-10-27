namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "6 3 1 6 5 -2 4";
            Permutation test = new Permutation(input);
            Console.WriteLine(test.Level1());
        }
    }
}