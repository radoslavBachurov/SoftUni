using System;
using System.Data;
using System.Data.SqlClient;

namespace _9.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
                 + "Integrated Security=true;");

            using (connection)
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("usp_GetOlder", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = inputId;
                    cmd.ExecuteNonQuery();
                }

                string selectString = "SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand selectCommand = new SqlCommand(selectString, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Id", inputId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetString(0)} – {reader.GetInt32(1)} years old");
                        }
                    }
                }
            }
        }
    }
}
