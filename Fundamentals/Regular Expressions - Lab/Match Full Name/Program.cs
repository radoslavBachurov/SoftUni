using System;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex validationName = new Regex (@"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b");
            MatchCollection matches = validationName.Matches(text);

            foreach (Match item in matches)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
