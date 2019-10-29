using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;
        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Rabbit>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count();

        public void Add(Rabbit rabbit)
        {
            if (data.Count < Capacity)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            if(data.Any(x=>x.Name==name))
            {
                data.Remove(data.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].Species==species)
                {
                    data.RemoveAt(i);
                    i--;
                }
            }
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbitToSell = data.FirstOrDefault(x => x.Name == name);
            rabbitToSell.Available = false;
            return rabbitToSell;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> rabbitsToReturn = new List<Rabbit>();
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].Species==species)
                {
                    data[i].Available = false;
                    rabbitsToReturn.Add(data[i]);
                }
            }

            Rabbit[] rabbitsArray = rabbitsToReturn.ToArray();
            return rabbitsArray;
        }

        public string Report()
        {
            List<Rabbit> notSold = data.Where(x => x.Available == true).ToList();
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"Rabbits available at {this.Name}:");
            for (int i = 0; i < notSold.Count; i++)
            {
                newSB.AppendLine(data[i].ToString());
            }

            return newSB.ToString().Trim();
        }

    }
}
