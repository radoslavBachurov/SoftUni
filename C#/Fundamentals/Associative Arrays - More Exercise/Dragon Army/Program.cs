using System;
using System.Collections.Generic;
using System.Linq;

namespace Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfDragonsAverage = new Dictionary<string, TypeDragonAverageStats>();
            var namedDragonsList = new Dictionary<string, List<NamedDragonStats>>();

            int countDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < countDragons; i++)
            {
                string[] inputArr = Console.ReadLine().Split().ToArray();

                string type = inputArr[0];
                string name = inputArr[1];

                NamedDragonStats newDragon = new NamedDragonStats(name);
                if (inputArr[2] != "null")
                {
                    double damage = double.Parse(inputArr[2]);
                    newDragon.Damage = damage;
                }
                if (inputArr[3] != "null")
                {
                    double health = double.Parse(inputArr[3]);
                    newDragon.Health = health;
                }
                if (inputArr[4] != "null")
                {
                    double armour = double.Parse(inputArr[4]);
                    newDragon.Armour = armour;
                }

                AddingNewDragon(listOfDragonsAverage, namedDragonsList, type, name, newDragon);

            }

            Printing(listOfDragonsAverage, namedDragonsList);
        }

        private static void AddingNewDragon(Dictionary<string, TypeDragonAverageStats> listOfDragonsAverage, Dictionary<string, List<NamedDragonStats>> namedDragonsList, string type, string name, NamedDragonStats newDragon)
        {
            if (!namedDragonsList.ContainsKey(type))
            {
                namedDragonsList.Add(type, new List<NamedDragonStats>());
                namedDragonsList[type].Add(newDragon);

                TypeDragonAverageStats newAverageDragon = new TypeDragonAverageStats();
                newAverageDragon.Armour = newDragon.Armour;
                newAverageDragon.Damage = newDragon.Damage;
                newAverageDragon.Health = newDragon.Health;
                newAverageDragon.Count++;
                listOfDragonsAverage[type] = newAverageDragon;
            }
            else
            {
                if (namedDragonsList[type].Any(x => x.Name == name))
                {
                    NamedDragonStats statsToSubstract = namedDragonsList[type].Find(x => x.Name == name);
                    listOfDragonsAverage[type].Armour -= statsToSubstract.Armour;
                    listOfDragonsAverage[type].Damage -= statsToSubstract.Damage;
                    listOfDragonsAverage[type].Health -= statsToSubstract.Health;

                    statsToSubstract.Armour = newDragon.Armour;
                    statsToSubstract.Damage = newDragon.Damage;
                    statsToSubstract.Health = newDragon.Health;

                    listOfDragonsAverage[type].Armour += statsToSubstract.Armour;
                    listOfDragonsAverage[type].Damage += statsToSubstract.Damage;
                    listOfDragonsAverage[type].Health += statsToSubstract.Health;
                }
                else
                {
                    namedDragonsList[type].Add(newDragon);
                    listOfDragonsAverage[type].Armour += newDragon.Armour;
                    listOfDragonsAverage[type].Damage += newDragon.Damage;
                    listOfDragonsAverage[type].Health += newDragon.Health;
                    listOfDragonsAverage[type].Count++;
                }
            }
        }

        private static void Printing(Dictionary<string, TypeDragonAverageStats> listOfDragonsAverage, Dictionary<string, List<NamedDragonStats>> namedDragonsList)
        {
            foreach (var averageDragon in listOfDragonsAverage)
            {
                Console.WriteLine($"{averageDragon.Key}::({(averageDragon.Value.Damage / averageDragon.Value.Count):f2}/{(averageDragon.Value.Health / averageDragon.Value.Count):f2}/{(averageDragon.Value.Armour / averageDragon.Value.Count):f2})");

                foreach (var namedDragon in namedDragonsList[averageDragon.Key].OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{namedDragon.Name} -> damage: {namedDragon.Damage}, health: {namedDragon.Health}, armor: {namedDragon.Armour}");
                }
            }
        }
    }
    class TypeDragonAverageStats
    {
        public TypeDragonAverageStats()
        {
            Damage = 0;
            Health = 0;
            Armour = 0;
            Count = 0;
        }
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armour { get; set; }
        public int Count { get; set; }

    }
    class NamedDragonStats
    {
        public NamedDragonStats(string name)
        {
            Damage = 45;
            Health = 250;
            Armour = 10;
            Name = name;
        }
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armour { get; set; }
        public string Name { get; set; }
    }
}
