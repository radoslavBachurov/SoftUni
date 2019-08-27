using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonNames = Console.ReadLine()
                .Split(new char[] { ',', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var demonList = new Dictionary<string, DemonAbility>();
            AddDemonHealth(demonNames, demonList);
            AddDemonDamage(demonNames, demonList);
            Printing(demonList);
        }

        private static void Printing(Dictionary<string, DemonAbility> demonList)
        {
            foreach (var demon in demonList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Health} health, {demon.Value.Damage:f2} damage");
            }
        }

        private static void AddDemonDamage(string[] demonNames, Dictionary<string, DemonAbility> demonList)
        {
            Regex numberValidation = new Regex(@"(-?\d*\.?\d+)");
            Regex multiplierValidation = new Regex(@"[*\/]");

            for (int i = 0; i < demonNames.Length; i++)
            {
                string demon = demonNames[i];
                decimal damage = 0;

                var numberMatches = numberValidation.Matches(demon);
                var multiplierMathes = multiplierValidation.Matches(demon);

                foreach (var pointNumber in numberMatches)
                {
                    damage += decimal.Parse(pointNumber.ToString());
                }

                foreach (var multiplier in multiplierMathes)
                {
                    string sign = multiplier.ToString();

                    switch (sign)
                    {
                        case "*":
                            damage *= 2;
                            break;
                        case "/":
                            damage /= 2;
                            break;
                    }
                }

                demonList[demon].Damage = damage;
            }
        }

        private static void AddDemonHealth(string[] demonNames, Dictionary<string, DemonAbility> demonList)
        {
            for (int i = 0; i < demonNames.Length; i++)
            {
                long sumHealth = 0;
                string demon = demonNames[i];

                Regex healthValidation = new Regex(@"[^0-9+\-*\/.]");
                var validChars = healthValidation.Matches(demon);

                foreach (var item in validChars)
                {
                    string match = item.ToString();

                    for (int t = 0; t < match.Length; t++)
                    {
                        sumHealth += match[t];
                    }
                }

                DemonAbility NewDemon = new DemonAbility();
                NewDemon.Health = sumHealth;
                demonList.Add(demon, NewDemon);
            }
        }
    }
    class DemonAbility
    {
        public DemonAbility()
        {
            Health = 0;
            Damage = 0;
        }
        public long Health { get; set; }
        public decimal Damage { get; set; }
    }
}
