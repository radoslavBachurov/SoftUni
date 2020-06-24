using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _5.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
               + "Integrated Security=true;");

            using (connection)
            {
                connection.Open();

                string stringCommand = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(stringCommand, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine($"{count} town names were affected.");

                        TakeCityNames(country, connection);
                    }
                    else
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                }
            }
        }

        private static void TakeCityNames(string country, SqlConnection connection)
        {
            string checkString = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";

            using (SqlCommand command = new SqlCommand(checkString, connection))
            {
                command.Parameters.AddWithValue("@countryName", country);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> countryList = new List<string>();
                    while (reader.Read())
                    {
                        countryList.Add(reader.GetString(0));
                    }

                    Console.WriteLine($"[{string.Join(", ", countryList)}]");
                }
            }
        }
    }
}

