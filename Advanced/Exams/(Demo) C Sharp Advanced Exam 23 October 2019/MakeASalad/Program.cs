using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vegetables = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            List<int> calories = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> caloriesOrign = new List<int>();
            for (int i = 0; i < calories.Count; i++)
            {
                caloriesOrign.Add(calories[i]);
            }

            var saladsReady = new List<int>();

            PreparingSalads(vegetables, calories);

            Printing(vegetables, calories, caloriesOrign, saladsReady);
        }

        private static void PreparingSalads(Queue<string> vegetables, List<int> calories)
        {
            while (calories.Count > 0 && vegetables.Count > 0)
            {
                string currentVegetable = vegetables.Dequeue();
                switch (currentVegetable)
                {
                    case "tomato":
                        calories[calories.Count - 1] -= 80;
                        break;
                    case "carrot":
                        calories[calories.Count - 1] -= 136;
                        break;
                    case "lettuce":
                        calories[calories.Count - 1] -= 109;
                        break;
                    case "potato":
                        calories[calories.Count - 1] -= 215;
                        break;
                }

                if (calories[calories.Count - 1] <= 0)
                {
                    calories.RemoveAt(calories.Count - 1);
                }
            }
        }

        private static void Printing(Queue<string> vegetables, List<int> calories, List<int> caloriesOrign, List<int> saladsReady)
        {
            if (calories.Any() &&
                calories[calories.Count - 1] != caloriesOrign[calories.Count - 1])
            {
                saladsReady.Add(caloriesOrign[calories.Count - 1]);
                calories.RemoveAt(calories.Count - 1);
            }

            for (int i = caloriesOrign.Count - 1; i >= calories.Count; i--)
            {
                Console.Write($"{caloriesOrign[i]} ");
            }
            Console.WriteLine();

            if (vegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            else
            {
                for (int i = calories.Count - 1; i >= 0; i--)
                {
                    Console.Write($"{calories[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
