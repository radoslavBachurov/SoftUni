using System;
using System.Text;

namespace Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine($"{PrintStr(str, count)}"); 
        }

        private static string PrintStr(string str , int numberCopies)
        {
            StringBuilder copiedString =  new StringBuilder();

            for (int i = 0; i < numberCopies; i++)
            {
                copiedString.Append(str);
            }

            return copiedString.ToString();
        }
    }
}
