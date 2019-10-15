using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> listOfTrainers = new Dictionary<string, Trainer>();

            CollectingPokemonsAndTrainers(listOfTrainers);
            TournamentStarting(listOfTrainers);

            Printing(listOfTrainers);
        }

        private static void Printing(Dictionary<string, Trainer> listOfTrainers)
        {
            foreach (var trainer in listOfTrainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.pokemonCollection.Count}");
            }
        }

        private static void TournamentStarting(Dictionary<string, Trainer> listOfTrainers)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in listOfTrainers)
                {
                    bool pokemonFinded = false;
                    foreach (var pokemon in trainer.Value.pokemonCollection)
                    {
                        if (pokemon.Element == command)
                        {
                            pokemonFinded = true;
                        }
                    }

                    if (pokemonFinded)
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Value.pokemonCollection.Count; i++)
                        {
                            trainer.Value.pokemonCollection[i].Health -= 10;

                            if (trainer.Value.pokemonCollection[i].Health <= 0)
                            {
                                trainer.Value.pokemonCollection.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
        }

        private static void CollectingPokemonsAndTrainers(Dictionary<string, Trainer> listOfTrainers)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = inputArr[0];
                string pokemonName = inputArr[1];
                string pokemonElement = inputArr[2];
                int pokemonHealth = int.Parse(inputArr[3]);

                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!listOfTrainers.ContainsKey(trainerName))
                {
                    listOfTrainers.Add(trainerName, new Trainer(trainerName));
                }

                listOfTrainers[trainerName].pokemonCollection.Add(newPokemon);
            }
        }
    }
}
