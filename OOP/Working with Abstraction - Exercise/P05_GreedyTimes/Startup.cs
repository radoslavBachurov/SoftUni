using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Startup
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] safeContent = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Bag myBag = new Bag(bagCapacity);

            StealingRichies(safeContent, myBag);

            Console.WriteLine(myBag.ToString());
        }

        private static void StealingRichies(string[] safeContent, Bag myBag)
        {
            for (int i = 0; i < safeContent.Length; i += 2)
            {
                string name = safeContent[i];
                long count = long.Parse(safeContent[i + 1]);

                string material = myBag.CheckMaterial(name, count);

                if (material == "")
                {
                    continue;
                }

                myBag.PutRiches(material, name, count);
            }
        }
    }
}