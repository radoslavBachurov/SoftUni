using System;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                text[i] += (char)3;
            }

            Console.WriteLine(string.Join("",text));
        }
    }
}
