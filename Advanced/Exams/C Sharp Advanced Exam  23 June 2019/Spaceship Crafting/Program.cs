using System;
using System.Collections.Generic;
using System.Linq;

namespace Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> items = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var materialsFinished = new Dictionary<string, AdvancedMaterial>();
            Addingmaterials(materialsFinished);

            while (liquids.Count > 0 && items.Count > 0)
            {
                if (CheckForCreatingItem(liquids, items, materialsFinished))
                {
                    liquids.Dequeue();
                    items.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    int newItem = items.Pop();
                    items.Push(newItem + 3);
                }
            }

            Printing(liquids, items, materialsFinished);
        }

        private static void Printing(Queue<int> liquids, Stack<int> items, Dictionary<string, AdvancedMaterial> materialsFinished)
        {
            if (CheckForSpaceShip(materialsFinished))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (items.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }

            foreach (var item in materialsFinished.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.count}");
            }
        }

        private static bool CheckForSpaceShip(Dictionary<string, AdvancedMaterial> materialsFinished)
        {
            foreach (var item in materialsFinished)
            {
                if (item.Value.count < 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckForCreatingItem(Queue<int> liquids, Stack<int> items, Dictionary<string, AdvancedMaterial> materialsFinished)
        {
            foreach (var item in materialsFinished)
            {
                if (liquids.Peek() + items.Peek() == item.Value.ValueNeeded)
                {
                    item.Value.count++;
                    return true;
                }
            }
            return false;
        }

        private static void Addingmaterials(Dictionary<string, AdvancedMaterial> materialsFinished)
        {
            materialsFinished.Add("Glass", new AdvancedMaterial(25));
            materialsFinished.Add("Aluminium", new AdvancedMaterial(50));
            materialsFinished.Add("Lithium", new AdvancedMaterial(75));
            materialsFinished.Add("Carbon fiber", new AdvancedMaterial(100));
        }
    }
    class AdvancedMaterial
    {
        public AdvancedMaterial(int value)
        {
            count = 0;
            this.ValueNeeded = value;
        }
        public int count { get; set; }
        public int ValueNeeded { get; private set; }
    }
}
