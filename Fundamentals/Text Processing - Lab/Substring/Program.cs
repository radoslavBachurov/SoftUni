using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine();
            string word = Console.ReadLine();


            while (true)
            {
                int index = word.IndexOf(toRemove);

                if (index < 0)
                {
                    break;
                }

                word = word.Remove(index, toRemove.Length);
            }

            Console.WriteLine(word);
        }
    }
}
