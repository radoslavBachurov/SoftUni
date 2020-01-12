using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            List<string> goodKids = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string decodedMessage = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    decodedMessage += (char)(input[i] - key);
                }

                Regex validaton = new Regex(@"@([A-Za-z]+)[^@\-!:>]*!(G|N)!");

                if (validaton.IsMatch(decodedMessage))
                {
                    var match = validaton.Match(decodedMessage);
                    var name = match.Groups[1].Value;
                    var behaviour = match.Groups[2].Value;

                    if (behaviour == "G")
                    {
                        goodKids.Add(name);
                    }
                }
            }

            foreach (var item in goodKids)
            {
                Console.WriteLine(item);
            }
        }
    }
}
