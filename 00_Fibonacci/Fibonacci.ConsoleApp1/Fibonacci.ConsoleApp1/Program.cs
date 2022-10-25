using System;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a = 0, b = 1, c = 0;
            for (int i = 2; i < 100; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.WriteLine($"{i}: {b}");
            }
            
        }
    }
}