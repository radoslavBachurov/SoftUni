using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("Resources", "input.txt");
            int count = 0;
            using (var reader = new StreamReader(filePath))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (count % 2 != 0)
                    {
                        using (var writer = new StreamWriter("output.txt", true))
                        {
                            writer.WriteLine(line);
                        }
                    }

                    count++;
                }
            }
        }
    }
}
