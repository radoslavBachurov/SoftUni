using System;
using System.Data.SqlClient;

namespace _6.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villanId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
               + "Integrated Security=true;");

            using (connection)
            {
                connection.Open();

                string stringCommand = "SELECT Name FROM Villains WHERE Id = @villainId";

                using (SqlCommand selectCommand = new SqlCommand(stringCommand, connection))
                {
                    selectCommand.Parameters.AddWithValue("@villainId", villanId);

                    string foundVillan = (string)selectCommand.ExecuteScalar();

                    if (foundVillan == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                    else
                    {
                        string stringDeleteMinions = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                        int minionsDeleted = 0;
                        using (SqlCommand deleteMinions = new SqlCommand(stringDeleteMinions, connection))
                        {
                            deleteMinions.Parameters.AddWithValue("@villainId", villanId);
                            minionsDeleted = (int)deleteMinions.ExecuteNonQuery();
                            
                        }

                        string stringDeleteVillain = "DELETE FROM Villains WHERE Id = @villainId";
                        using (SqlCommand deleteVillan = new SqlCommand(stringDeleteVillain, connection))
                        {
                            deleteVillan.Parameters.AddWithValue("@villainId", villanId);
                            deleteVillan.ExecuteNonQuery();
                        }

                        Console.WriteLine($"{foundVillan} was deleted.");
                        Console.WriteLine($"{minionsDeleted} minions were released.");
                    }
                }
            }
        }
    }
}
