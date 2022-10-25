using System;

namespace GeneticDrift
{
    internal class Program
    {
        static void Main(string[] args)
        {

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