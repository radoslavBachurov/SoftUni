using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Utilities
{
    public static class AstronautValidatorType
    {
        public static bool ValidateAstronautType(string type)
        {

            switch (type)
            {
                case "Biologist":
                    return true;
                    break;
                case "Geodesist":
                    return true;
                    break;
                case "Meteorologist":
                    return true;
                    break;
            }

            return false;
        }
    }
}
