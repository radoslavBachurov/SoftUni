using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("Resources", "input.txt");

            using (var reader = new StreamReader(filePath))
            {
                string line = string.Empty;
                int count = 1;
                while ((line = reader.ReadLine())!=null)
                {
                    using (var write = new StreamWriter("output.txt",true))
                    {
                        write.WriteLine($"{count}. {line}");
                    }
                    count++;
                }
            }
        }
    }
}
