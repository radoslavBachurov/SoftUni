using System;
using System.Linq;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (playerType == null)
            {
                throw new ArgumentException("Player of this type does not exists!");
            }

            var constructor = playerType
                .GetConstructors().First();

            var newPlayer =(IPlayer)constructor.Invoke(new object[] { username, new CardRepository()});

            return newPlayer;
        }
    }
}
