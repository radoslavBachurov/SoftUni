using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player, IPlayer
    {
        public Advanced(string username, ICardRepository cardRepo)
            : base(username, 250, cardRepo)
        {
        }
    }
}
