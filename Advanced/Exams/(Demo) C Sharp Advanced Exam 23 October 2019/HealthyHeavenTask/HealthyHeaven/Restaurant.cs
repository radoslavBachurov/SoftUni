using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;
        public Restaurant(string name)
        {
            this.Name = name;
            data = new List<Salad>();
        }
        public string Name { get; set; }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            if(data.Any(x=>x.Name==name))
            {
                data.Remove(data.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public Salad GetHealthiestSalad()
        {
            Salad healthiest = data[0];
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].GetTotalCalories()<healthiest.GetTotalCalories())
                {
                    healthiest = data[i];
                }
            }
            return healthiest;
        }

        public string GenerateMenu()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"{this.Name} have {data.Count} salads: ");
            for (int i = 0; i < data.Count; i++)
            {
                newSB.AppendLine(data[i].ToString());
            }
            return newSB.ToString().Trim();
        }

    }
}
