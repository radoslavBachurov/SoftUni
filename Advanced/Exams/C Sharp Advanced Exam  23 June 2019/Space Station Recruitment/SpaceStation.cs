using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;
        public SpaceStation(string name, int capacity)
        {
            data = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count();

        public void Add(Astronaut astronaut)
        {
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                data.Remove(data.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldest = data[0];

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Age > oldest.Age)
                {
                    oldest = data[i];
                }
            }

            return oldest;
        }

        public Astronaut GetAstronaut(string name)
        {
            return data.Find(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"Astronauts working at Space Station {this.Name}:");

            for (int i = 0; i < data.Count; i++)
            {
                newSB.AppendLine(data[i].ToString());
            }

            return newSB.ToString().Trim();
        }
    }
}
