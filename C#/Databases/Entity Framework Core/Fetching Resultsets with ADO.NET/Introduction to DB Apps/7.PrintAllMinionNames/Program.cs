using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _7.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
                + "Integrated Security=true;");

            using (connection)
            {
                connection.Open();

                string stringCommand = "SELECT Name FROM Minions";

                using (SqlCommand selectCommand = new SqlCommand(stringCommand, connection))
                {
                    List<string> listMinions = new List<string>();
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listMinions.Add(reader.GetString(0));
                        }
                        
                    }

                    while (listMinions.Count>1)
                    {
                        Console.WriteLine($"{listMinions[0]}");
                        listMinions.RemoveAt(0);

                        Console.WriteLine($"{listMinions[^1]}");
                        listMinions.RemoveAt(listMinions.Count-1);
                    }

                    if (listMinions.Count == 1)
                    {
                        Console.WriteLine($"{listMinions[0]}");
                    }
                }
            }
        }
    }
}
