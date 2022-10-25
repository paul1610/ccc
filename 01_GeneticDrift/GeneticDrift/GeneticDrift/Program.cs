using System;

namespace GeneticDrift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "8 0 3 1 6 5 -2 4 7";
            int[] inputInt = Array.ConvertAll(input.Split(' '), int.Parse);
        }

        static int[] PushToArray(int[] x, int yourNumber)
        {
            int[] y = new int[x.Length + 1];
            for (int i = 0; i < x.Length; i++)
            {
                y[i] = x[i];
            }
            y[x.Length] = yourNumber;
            return y;
        }

        static void Output(int[] output)
        {
            Console.WriteLine($"Output: {String.Join(",", output)}");
        }
    }
}