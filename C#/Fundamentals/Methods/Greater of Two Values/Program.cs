using System;

namespace Greater_of_Two_Values
{
    class Program
    {
        public static object GetStringMax { get; private set; }

        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            int firstInteger;
            int secondInteger;
            char firstChar;
            char secondChar;

            if (int.TryParse(firstInput, out firstInteger) &&
                int.TryParse(secondInput, out secondInteger))
            {
                Console.WriteLine(GetMax(firstInteger, secondInteger));
            }
            else if (char.TryParse(firstInput, out firstChar) &&
                     char.TryParse(secondInput, out secondChar))
            {
                Console.WriteLine(GetMax(firstChar, secondChar));
            }
            else
            {
                Console.WriteLine(GetMax(firstInput, secondInput));
            }

            

        }

        private static int GetMax(int firstInteger, int secondInteger)
        {
            return Math.Max(firstInteger, secondInteger);
        }

        private static char GetMax(char firstChar, char secondChar)
        {
            int firstInteger = (int)firstChar;
            int secondInteger = (int)secondChar;
            return (char)Math.Max(firstInteger, secondInteger);
        }

        private static string GetMax(string firststr, string secondstr)
        {
            string larger = string.Empty;
            if (firststr.CompareTo(secondstr) >= 0)
                larger = firststr;
            else
                larger = secondstr;

            return larger;
        }
    }



}
