using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Utilities
{
    public static class AstronautFactory
    {
        public static IAstronaut CreateAstronaut(string type, string name)
        {
            var astrType = typeof(StartUp)
                .Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            var constructor = astrType.GetConstructor(new Type[] { typeof(string) });
            var instance = (IAstronaut)constructor.Invoke(new object[] { name });

            return instance;
        }
    }
}
