using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            pokemonCollection = new List<Pokemon>();
        }
        public string Name  { get; set; }
        public int Badges  { get; set; }
        public List<Pokemon> pokemonCollection  { get; set; }
    }
}
