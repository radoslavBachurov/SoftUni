using System;
using System.Data.SqlClient;

namespace _3.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
                + "Integrated Security=true;");

            string input = Console.ReadLine();

            string selectName = $@"SELECT Name FROM Villains WHERE Id = @input";

            string selectMinions = @$"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                     FROM MinionsVillains AS mv
                                     JOIN Minions As m ON mv.MinionId = m.Id
                                     WHERE mv.VillainId = @input
                                     ORDER BY m.Name";

            using (connection)
            {
                connection.Open();

                using (SqlCommand commandName = new SqlCommand(selectName, connection))
                {
                    commandName.Parameters.AddWithValue("@input", input);
                    string readerName = (string)commandName.ExecuteScalar();

                    if (readerName != null)
                    {
                        Console.WriteLine($"Villain: {readerName}");

                        using (SqlCommand commandMinions = new SqlCommand(selectMinions, connection))
                        {
                            commandMinions.Parameters.AddWithValue("@input", input);
                            SqlDataReader readerMinions = commandMinions.ExecuteReader();

                            if (readerMinions.HasRows)
                            {
                                while (readerMinions.Read())
                                {
                                    Console.WriteLine($"{readerMinions.GetInt64(0)}. {readerMinions.GetString(1)} {readerMinions.GetInt32(2)}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("(no minions)");
                            }
                            readerMinions.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {input} exists in the database.");
                    }
                }
            }
        }
    }
}
