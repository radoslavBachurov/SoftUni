using System;

namespace Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberChars = int.Parse(Console.ReadLine());
            string decryptedMessage = string.Empty;

            for (int i = 0; i < numberChars; i++)
            {
                char Character = char.Parse(Console.ReadLine());
                char sum = (char)(Character + key);
                decryptedMessage += sum.ToString();
            }
            Console.WriteLine(decryptedMessage);

        }
    }
}
