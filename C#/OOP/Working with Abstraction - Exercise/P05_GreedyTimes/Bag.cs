using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        private long capacity;
        private long totalAmountInBag;
        private Dictionary<string, long> gold;
        private Dictionary<string, long> gems;
        private Dictionary<string, long> cash;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.gold = new Dictionary<string, long>();
            this.gems = new Dictionary<string, long>();
            this.cash = new Dictionary<string, long>();
            gold.Add("Gold", 0);
        }

        private long TotalAmountInBag => this.gold.Values.Sum() + this.gems.Values.Sum() + this.cash.Values.Sum();

        public void PutRiches(string material, string name, long count)
        {
            switch (material)
            {
                case "Gem":
                    {
                        if (this.gems.Values.Sum() + count <= this.gold.Values.Sum())
                        {
                            if (!gems.ContainsKey(name))
                            {
                                gems.Add(name, 0);
                            }
                            gems[name] += count;
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Cash":
                    if (this.cash.Values.Sum() + count <= this.gems.Values.Sum())
                    {
                        if (!cash.ContainsKey(name))
                        {
                            cash.Add(name, 0);
                        }
                        cash[name] += count;
                    }
                    else
                    {
                        return;
                    }
                    break;

                case "Gold":
                    {
                       this.gold["Gold"] += count;
                    }
                    break;
            }
        }

        public string CheckMaterial(string name, long count)
        {
            string material = string.Empty;

            if (name.Length == 3)
            {
                material = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                material = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                material = "Gold";
            }

            if (material == "")
            {
                material = "";
            }
            else if (capacity < totalAmountInBag + count)
            {
                material = "";
            }

            return material;
        }

        public override string ToString()
        {
            var totalValues = new Dictionary<string, Dictionary<string, long>>();
            totalValues.Add("Gold", gold);
            totalValues.Add("Gem", gems);
            totalValues.Add("Cash", cash);

            StringBuilder newSB = new StringBuilder();
            foreach (var material in totalValues.OrderByDescending(x=>x.Value.Values.Sum())
                .Where(x=>x.Value.Values.Sum()>0))
            {
                newSB.AppendLine($"<{material.Key}> ${material.Value.Values.Sum()}");

                foreach (var secondMaterial in material.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    newSB.AppendLine($"##{secondMaterial.Key} - {secondMaterial.Value}");
                }
            }
            return newSB.ToString().Trim();
        }
    }
}
