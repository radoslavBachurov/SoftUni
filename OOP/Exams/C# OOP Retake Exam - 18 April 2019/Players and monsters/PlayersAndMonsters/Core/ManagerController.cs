namespace PlayersAndMonsters.Core
{
    using System;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Repositories.Contracts;
    using Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IPlayerRepository playerRepo;
        private ICardRepository cardRepo;

        public ManagerController(IPlayerFactory playerFactory,
                                 ICardFactory cardFactory,
                                 IPlayerRepository playerRepo,
                                 ICardRepository cardRepo)
        {
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.playerRepo = playerRepo;
            this.cardRepo = cardRepo;
        }

        public string AddPlayer(string type, string username)
        {
            throw new NotImplementedException();
        }

        public string AddCard(string type, string name)
        {
            throw new NotImplementedException();
        }

        public string AddPlayerCard(string username, string cardName)
        {
            throw new NotImplementedException();
        }

        public string Fight(string attackUser, string enemyUser)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
