using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfDwarfs = new List<Dwarf>();
            AddingDwarfs(listOfDwarfs);

            Printing(listOfDwarfs);
        }

        private static void Printing(List<Dwarf> listOfDwarfs)
        {
            foreach (var item in listOfDwarfs)
            {
                for (int i = 0; i < listOfDwarfs.Count; i++)
                {
                    if (listOfDwarfs[i].HatColor == item.HatColor)
                    {
                        item.HatCount++;
                    }
                }
            }

            foreach (var dwarf in listOfDwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => x.HatCount))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }

        private static void AddingDwarfs(List<Dwarf> listOfDwarfs)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputArr = input.Split(" <:> ").ToArray();
                string name = inputArr[0];
                string hatColor = inputArr[1];
                int physics = int.Parse(inputArr[2]);

                bool differentDwarf = true;
                foreach (var dwarf in listOfDwarfs)
                {
                    if (dwarf.HatColor == hatColor && dwarf.Name == name)
                    {
                        dwarf.Physics = Math.Max(dwarf.Physics, physics);
                        differentDwarf = false;
                    }
                }

                if (differentDwarf)
                {
                    Dwarf newDwarf = new Dwarf(name, physics, hatColor);
                    listOfDwarfs.Add(newDwarf);
                }

            }
        }
    }
    class Dwarf
    {
        public Dwarf(string name, int physics, string hatColor)
        {
            Name = name;
            Physics = physics;
            HatColor = hatColor;
            HatCount = 0;
        }
        public string Name { get; set; }
        public int Physics { get; set; }
        public string HatColor { get; set; }
        public int HatCount { get; set; }
    }
}
