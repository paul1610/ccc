using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Util
{
    internal class MiscUtil
    {
        public static T[] CloneArray<T>(T[] array)
        {
            return (T[])array.Clone();
        }

        public static T[] MergeArrays<T>(params T[][] arrays)
        {
            return arrays.SelectMany(x => x).ToArray();
        }

        public static DateTime AddBusinessDays(DateTime date, int days)
        {
            int sign = Math.Sign(days);
            while (days != 0)
            {
                date = date.AddDays(sign);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    days -= sign;
            }
            return date;
        }

        private static Random _random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max + 1);
        }

        public static T GetRandomElement<T>(List<T> list)
        {
            return list[GenerateRandomNumber(0, list.Count - 1)];
        }
    }
}
