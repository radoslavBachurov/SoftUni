using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player, IPlayer
    {
        public Beginner(string username, ICardRepository cardRepo)
            : base(username, 50, cardRepo)
        {
        }
    }
}
