using System;

namespace GeneticDrift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "6 3 1 6 5 -2 4";
            int[] inputInt = Array.ConvertAll(input.Split(' '), int.Parse);
            inputInt = FindOrientedPaars(inputInt);
            inputInt = Sort(inputInt);
            Output(inputInt);
        }

        static int[] CombineArrays(int[] x, int[] yourNumber)
        {
            int[] y = new int[x.Length + yourNumber.Length];
            for (int i = 0; i < x.Length; i++)
            {
                y[i] = x[i];
            }
            for (int i = x.Length; i < yourNumber.Length + x.Length; i++)
            {
                y[i] = yourNumber[i - x.Length];
            }
            return y;
        }

        static int[] Sort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i += 2)
            {
                for (int j = 0; j < arr.Length; j += 2)
                {
                    if (arr[j] <= arr[i])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }

        static int[] FindOrientedPaars(int[] inputList)
        {
            int[] outputList = new int[0];
            int[] temp = new int[2];
            for (int i = 0; i < inputList.Length; i++)
            {
                for (int n = i; n < inputList.Length; n++)
                {
                    if (inputList[n] + inputList[i] == -1 || inputList[n] + inputList[i] == 1)
                    {
                        temp[0] = inputList[n];
                        temp[1] = inputList[i];
                        outputList = CombineArrays(outputList, temp);
                    }
                }
            }
            return outputList;
        }

        static void Output(int[] output)
        {
            Console.WriteLine($"Output: {output.Length / 2} {String.Join(" ", output)}");
        }
    }
}