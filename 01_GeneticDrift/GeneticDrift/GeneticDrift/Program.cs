using System;
using System.Dynamic;

namespace GeneticDrift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "8 0 3 1 6 5 -2 4 7";
            int[] inputInt = Array.ConvertAll(input.Split(' '), int.Parse);
            inputInt = FindOrientedPaars(inputInt);
            inputInt = LolDieAngabeIsDumm(inputInt);
            foreach (int item in inputInt)
            {
                Console.Write(item);
                Console.Write(' ');
            }
            Console.WriteLine();
            List<Pair> pairs = GetPairs(inputInt);
            Output(pairs);
            Console.WriteLine(  );
            List<Pair> sortedList = Sort(pairs);
            Output(sortedList);
        }

        static int[] LolDieAngabeIsDumm(int[] x)
        {
            int temp;
            for(int i = 0; i < x.Length; i += 2)
            {
                if (x[i] < x[i + 1])
                {
                    temp = x[i + 1];
                    x[i + 1] = x[i];
                    x[i + 1] = temp;
                }
            }
            return x;
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

        static List<Pair> Sort(List<Pair> arr)
        {
            int temp, changes = 1;

            while(changes != 0) { 
                changes = 0;
                for (int i = 1; i < arr.Count; i++)
                {
                    if (arr[i-1].X > arr[i].X)
                    {
                        changes++;
                        Pair tmp = arr[i-1];
                        arr[i-1] = arr[i];
                        arr[i] = tmp;
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
        
        public static List<Pair> GetPairs(int[] input)
        {
            List<Pair> pairs = new List<Pair>();
            Pair tmp = new Pair();
            for (int i = 0; i < input.Length; i++)
            {
                if(tmp.X == null)
                {
                    tmp.X = input[i];
                }
                else
                {
                    tmp.Y = input[i];
                    if(tmp.X < tmp.Y)
                    {
                        int? inte = tmp.Y;
                        tmp.Y = tmp.X;
                        tmp.X = inte;
                    }
                    if (tmp.X != 0 && tmp.Y != 0)
                    {
                        pairs.Add(tmp);
                    }
                    tmp = new Pair();
                }
            }
            return pairs;
        }

        static void Output(List<Pair> output)
        {
            Console.Write(output.Count);
            foreach(var item in output)
            {
                Console.Write($" {item.X} {item.Y}");
            }
        }
    }
}
