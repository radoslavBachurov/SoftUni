using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materialsList = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;
            bool targetReached = false;

            while (!targetReached)
            {
                string[] input = Console.ReadLine().ToLower().Split().ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {
                    if (keyMaterials.ContainsKey(input[i + 1]))
                    {
                        Keymaterials(keyMaterials, input, i);

                        targetReached = CheckForLegendaryWeapon(keyMaterials, input[i + 1]);

                        if (targetReached)
                        {
                            break;
                        }

                        continue;
                    }
                    Junk(materialsList, input, i);
                }

            }

            PrintingAndSorting(materialsList, keyMaterials);
        }

        private static void PrintingAndSorting(Dictionary<string, int> materialsList, Dictionary<string, int> keyMaterials)
        {
            foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in materialsList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void Keymaterials(Dictionary<string, int> keyMaterials, string[] input, int i)
        {
            if (keyMaterials.ContainsKey(input[i + 1]))
            {

                keyMaterials[input[i + 1]] += int.Parse(input[i]);
            }
            else
            {
                keyMaterials.Add(input[i + 1], int.Parse(input[i]));
            }
        }

        private static void Junk(Dictionary<string, int> materialsList, string[] input, int i)
        {
            if (materialsList.ContainsKey(input[i + 1]))
            {

                materialsList[input[i + 1]] += int.Parse(input[i]);
            }
            else
            {
                materialsList.Add(input[i + 1], int.Parse(input[i]));
            }
        }

        private static bool CheckForLegendaryWeapon(Dictionary<string, int> materialsList, string material)
        {
            bool obtained = false;

            if (materialsList[material] >= 250)
            {

                materialsList[material] -= 250;
                obtained = true;

                if (material == "shards")
                {
                    Console.WriteLine("Shadowmourne obtained!");
                }
                else if (material == "motes")
                {
                    Console.WriteLine("Dragonwrath obtained!");
                }
                else if (material == "fragments")
                {
                    Console.WriteLine("Valanyr obtained!");
                }
            }
            return obtained;
        }
    }
}

