using System;

namespace Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int gold = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    partySize -= 2;
                }
                if (i % 15 == 0)
                {
                    partySize += 5;
                }

                gold += 50 - (2 * partySize);

                if (i % 3 == 0)
                {
                    gold -= 3 * partySize;
                }

                if (i % 5 == 0)
                {
                    gold += 20 * partySize;

                    if (i % 3 == 0)
                    {
                        gold -= 2 * partySize;
                    }
                }
            }

            int goldPerPerson = (int)(Math.Floor((double)gold / partySize));

            Console.WriteLine($"{partySize} companions received {goldPerPerson} coins each.");
        }
    }
}
