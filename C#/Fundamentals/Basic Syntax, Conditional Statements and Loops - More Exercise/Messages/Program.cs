using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int pushCount = int.Parse(Console.ReadLine());
            int counter = 0;
            string sentence = string.Empty;

            while (counter < pushCount)
            {
                counter++;
                string wordNumber = Console.ReadLine();
                int lenght = wordNumber.Length;
                int digitNumber = int.Parse(wordNumber);

                if(digitNumber==0)
                {
                    sentence += " ";
                    continue;
                }

                double mainDigit = digitNumber % 10.0;
                double offset = 0;

                if (mainDigit != 8 && mainDigit != 9)
                {
                    offset = (mainDigit - 2) * 3;
                }

                else
                {
                    offset = ((mainDigit - 2) * 3) + 1;
                }

                double letterIndex = (offset + lenght - 1) + 97;
                sentence += (char)letterIndex;
                
            }
            Console.Write(sentence);




        }
    }
}
