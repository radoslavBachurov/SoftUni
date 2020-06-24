using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Initial_Setup
{
    public static class ConnectionString
    {
        const string settingString = "Data Source=DESKTOP-FDQOU2P;;"
                + "Integrated Security=true;";

        const string databaseString = "Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
                + "Integrated Security=true;";
        static public string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return settingString;
        }

        static public string GetConnectionBase()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return databaseString;
        }
    }
}
