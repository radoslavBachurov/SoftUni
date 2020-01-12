namespace MortalEngines
{
    using MortalEngines.IO.Contracts;
    using MortalEngines.Core.Contracts;
    using MortalEngines.Core;

    public class StartUp
    {
        public static void Main()
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();



            IMachinesManager manager = new MachinesManager();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

            IEngine newEngine = new Engine(writer, reader, commandInterpreter);
            newEngine.Run();
        }
    }
}