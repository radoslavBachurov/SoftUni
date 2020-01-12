using System;

namespace English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string lastDigit = (number % 10).ToString();
            string digitLetter = string.Empty;
            switch (lastDigit)
            {
                case "1":
                    digitLetter = "one";
                    break;
                case "2":
                    digitLetter = "two";
                    break;
                case "3":
                    digitLetter = "three";
                    break;
                case "4":
                    digitLetter = "four";
                    break;
                case "5":
                    digitLetter = "five";
                    break;
                case "6":
                    digitLetter = "six";
                    break;
                case "7":
                    digitLetter = "seven";
                    break;
                case "8":
                    digitLetter = "eight";
                    break;
                case "9":
                    digitLetter = "nine";
                    break;
                case "0":
                    digitLetter = "zero";
                    break;
            }
            Console.WriteLine(digitLetter);
        
        }
    }
}
