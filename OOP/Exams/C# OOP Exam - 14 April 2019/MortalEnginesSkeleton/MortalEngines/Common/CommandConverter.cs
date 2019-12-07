
namespace MortalEngines.Common
{
    public static class CommandConverter
    {
        public static string Convert(string toConvert)
        {
            string converted = string.Empty;

            switch (toConvert)
            {
                case "AggressiveMode":
                    converted = "ToggleFighterAggressive";
                    break;
                case "DefenseMode":
                    converted = "ToggleTankDefenseMode";
                    break;
                case "Engage":
                    converted = "EngageMachine";
                    break;
                case "Attack":
                    converted = "AttackMachines";
                    break;
                default:
                    converted = toConvert;
                    break;
            }

            return converted;
        }
    }
}
