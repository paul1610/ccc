using System.IO;
using System;

string[] inputPaths = new string[] { "in1.txt", "in2.txt", "in3.txt" };
string[] outputPaths = new string[] { "out1.txt", "out2.txt", "out3.txt" };

List<string> ouptToFile = new List<string>();
string hold;

for(int i = 0; i < inputPaths.Length; i++)
{
    foreach(string s in File.ReadLines(inputPaths[i]))
    {
        hold = Run(s);
        Console.WriteLine(hold);
        ouptToFile.Add(hold);
    }

    File.WriteAllLines(outputPaths[i], ouptToFile);
    ouptToFile.Clear();
}

static string Run(string line)
{
    string output = "";

    //code here


    return output;
}