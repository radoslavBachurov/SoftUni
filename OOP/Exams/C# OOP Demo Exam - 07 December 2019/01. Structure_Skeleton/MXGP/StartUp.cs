using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IChampionshipController championShipController = new ChampionshipController();

            var newEngine = new Engine(championShipController);
            newEngine.Run();
        }
    }
}
