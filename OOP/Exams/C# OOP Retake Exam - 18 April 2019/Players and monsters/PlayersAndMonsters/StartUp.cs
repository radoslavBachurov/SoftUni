namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();

            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();
            IPlayerRepository playerRepo = new PlayerRepository();
            ICardRepository cardRepo = new CardRepository();
            IBattleField battlefield = new BattleField();

            IManagerController managerController = new ManagerController(playerFactory,
                                                                         cardFactory,
                                                                         playerRepo,
                                                                         cardRepo,
                                                                         battlefield);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(managerController);
            var newEngine = new Engine(commandInterpreter, reader, writer);
            newEngine.Run();
        }
    }
}