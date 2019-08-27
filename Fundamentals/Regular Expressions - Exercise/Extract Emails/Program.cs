using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailsInput = Console.ReadLine();

            Regex emailValidator = new Regex(@"(?<= )[A-Za-z][\w.-]+@[A-Za-z-]+\.[A-Za-z-]+[.]?[A-Za-z-]+");
            var matches = emailValidator.Matches(emailsInput);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
