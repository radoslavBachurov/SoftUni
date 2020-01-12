using System;
using System.Linq;
using System.Text;

namespace Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            var sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                for (int t = 0; t < words[i].Length; t++)
                {
                    sb.Append(words[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
