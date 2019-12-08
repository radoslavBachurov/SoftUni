namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using Contracts;
    using PlayersAndMonsters.Common;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IPlayerRepository playerRepo;
        private ICardRepository cardRepo;
        private IBattleField battlefield;

        public ManagerController(IPlayerFactory playerFactory,
                                 ICardFactory cardFactory,
                                 IPlayerRepository playerRepo,
                                 ICardRepository cardRepo,
                                 IBattleField battlefield)
        {
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.playerRepo = playerRepo;
            this.cardRepo = cardRepo;
            this.battlefield = battlefield;
        }

        public string AddPlayer(string type, string username)
        {
            var newPlayer = playerFactory.CreatePlayer(type, username);

            playerRepo.Add(newPlayer);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, newPlayer.GetType().Name, newPlayer.Username);
        }

        public string AddCard(string type, string name)
        {
            var newCard = cardFactory.CreateCard(type, name);
            cardRepo.Add(newCard);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, newCard.GetType().Name, newCard.Name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepo.Find(username);
            var card = cardRepo.Find(cardName);

            player.CardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, card.Name, player.Username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var atacker = playerRepo.Find(attackUser);
            var enemy = playerRepo.Find(enemyUser);
            battlefield.Fight(atacker, enemy);

            return string.Format(ConstantMessages.FightInfo, atacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder newSB = new StringBuilder();

            var players = playerRepo.Players;

            foreach (var player in players)
            {
                newSB.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username, player.Health, player.CardRepository.Cards.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    newSB.AppendLine(string.Format(ConstantMessages.CardReportInfo,
                        card.Name, card.DamagePoints));
                }

                newSB.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return newSB.ToString().Trim();
        }
    }
}
