using System;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Repositories;
using System.Linq;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + "Card");

            var constructor = cardType
              .GetConstructors().First();

            var newCard = (ICard)constructor.Invoke(new object[] { name });

            return newCard;
        }
    }
}
