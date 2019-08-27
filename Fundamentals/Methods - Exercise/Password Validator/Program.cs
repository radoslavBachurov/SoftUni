using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool correctPassword = true;

            correctPassword = LenghtCheck(password, correctPassword);
            correctPassword = LettersAndDigitsCheck(password, correctPassword);
            correctPassword = DigitsCountCheck(password, correctPassword);

            if(correctPassword)
                Console.WriteLine("Password is valid");
        }

        private static bool DigitsCountCheck(string password, bool correctPassword)
        {
            var count = password.Count(Char.IsDigit);
            if (count < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                 correctPassword = false;
             }
            return correctPassword;
        }

        private static bool LettersAndDigitsCheck(string password, bool correctPassword)
        {
            if (!(Regex.IsMatch(password, @"^[a-zA-Z0-9]+$")))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                correctPassword = false;
            }
            return correctPassword;
        }

        private static bool LenghtCheck(string password, bool correctPassword)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                correctPassword = false;
            }
            return correctPassword;
        }
    }
}
