using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex numberValidator = new Regex(@"([ ]|^)[+]359( |-)2\2[0-9]{3}\2[0-9]{4}\b");

            var matches = numberValidator.Matches(text);

            List<string> listOfMatches = new List<string>();

            foreach (Match item in matches)
            {
                listOfMatches.Add(item.ToString());
            }

            Console.WriteLine(string.Join(",",listOfMatches));
        }
    }
}
