using System;
using System.Data.SqlClient;
using System.Linq;

namespace _8.IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
                 + "Integrated Security=true;");

            using (connection)
            {
                connection.Open();

                string stringCommandUpdate = $"UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1  WHERE Id IN ({string.Join(",",input)})";

                using (SqlCommand updateCommand = new SqlCommand(stringCommandUpdate, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                string stringCommandSelect = "SELECT Name, Age FROM Minions";

                using (SqlCommand selectCommand = new SqlCommand(stringCommandSelect, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetString(0)} {reader.GetInt32(1)}");
                        }
                    }
                }
            }
        }
    }
}
