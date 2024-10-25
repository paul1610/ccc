using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Util
{
    internal class StringUtil
    {
        public static string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsPalindrome(string input)
        {
            return input == Reverse(input);
        }

        public static string RemoveDuplicates(string input)
        {
            string result = string.Empty;
            foreach (char c in input)
            {
                if (result.IndexOf(c) == -1)
                    result += c;
            }
            return result;
        }

        public static int CountOccurrences(string input, char target)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == target)
                    count++;
            }
            return count;
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}
