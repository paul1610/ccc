using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Util
{
    internal class FileUtil
    {
        public static string[] ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public static string ReadText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static List<string[]> ParseCSV(string filePath)
        {
            List<string[]> records = new List<string[]>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    records.Add(values);
                }
            }
            return records;
        }
    }
}
