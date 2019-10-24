using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            products = new List<Vegetable>();
            this.Name = name;
        }
        public string Name { get; set; }

        public int GetTotalCalories()
        {
            int sumCalories = 0;
            for (int i = 0; i < products.Count; i++)
            {
                sumCalories += products[i].Calories;
            }
            return sumCalories;
        }

        public int GetProductCount()
        {
            int Count = products.Count;
            return Count;
        }

        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
            for (int i = 0; i < products.Count; i++)
            {
                newSB.AppendLine(products[i].ToString());
            }

            return newSB.ToString().Trim();
        }
    }
}
