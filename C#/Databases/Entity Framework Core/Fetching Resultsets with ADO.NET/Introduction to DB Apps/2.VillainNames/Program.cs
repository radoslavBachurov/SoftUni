using System;
using System.Data.SqlClient;

namespace _2.VillainNames
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
                + "Integrated Security=true;");

            string selectCommand = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                                        FROM Villains AS v
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                    GROUP BY v.Id, v.Name
                                      HAVING COUNT(mv.VillainId) > 3
                                    ORDER BY COUNT(mv.VillainId)";
            using (connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetString(0)} - {reader.GetInt32(1)}");
                        }
                    }
                }
            }
        }
    }
}
