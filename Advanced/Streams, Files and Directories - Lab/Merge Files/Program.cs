using System;
using System.IO;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileOnePath = Path.Combine("Resources", "FileOne.txt");
            string fileTwoPath = Path.Combine("Resources", "FileTwo.txt");

            string[] fileOne = File.ReadAllLines(fileOnePath);
            string[] fileTwo = File.ReadAllLines(fileTwoPath);

            using (var writer = new StreamWriter("output.txt"))
            {
                for (int i = 0; i < Math.Max(fileOne.Length, fileTwo.Length); i++)
                {
                    if (fileOne.Length > i)
                    {
                        writer.WriteLine(fileOne[i]);
                    }
                    if (fileTwo.Length > i)
                    {
                        writer.WriteLine(fileTwo[i]);
                    }
                }
            }
        }
    }
}
