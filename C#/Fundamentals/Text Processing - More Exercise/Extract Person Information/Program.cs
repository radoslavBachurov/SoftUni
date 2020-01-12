using System;
using System.Text.RegularExpressions;

namespace Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Regex extractName = new Regex(@"@([A-Za-z]*)\|");
                Regex extractAge = new Regex(@"#(\d+)\*");

                var name = extractName.Match(input);
                var age = extractAge.Match(input);

                Console.WriteLine($"{name.Groups[1].Value} is {age.Groups[1].Value} years old.");
            }
        }
    }
}
