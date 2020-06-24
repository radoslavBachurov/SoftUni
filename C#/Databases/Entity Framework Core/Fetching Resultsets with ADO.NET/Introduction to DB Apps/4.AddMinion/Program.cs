using System;
using System.Data.SqlClient;

namespace _4.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];
            string villainName = villainInfo[1];

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FDQOU2P;Database=MinionsDB;"
               + "Integrated Security=true;");

            using (connection)
            {
                connection.Open();

                string selectTown = "SELECT Id FROM Towns WHERE Name = @townName";
                string selectVillain = "SELECT Id FROM Villains WHERE Name = @Name";
                string selectMinion = "SELECT Id FROM Minions WHERE Name = @Name";

                int townID = CheckTown(minionTown, connection, selectTown);

                int minionID = CheckMinion(minionName, minionAge, connection, townID, selectMinion);

                int villainID = CheckVillain(villainName, connection, selectVillain);

                InsertMinionVillain(connection, minionID, villainID, minionName, villainName);
            }
        }

        private static void InsertMinionVillain(SqlConnection connection, int minionID, int villainID, string minionName, string villainName)
        {
            string insertMinionVillain = "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@minionId,@villainId)";
            string checkVillainMinionCode = "SELECT VillainId FROM MinionsVillains WHERE MinionId = @minionID";

            using (SqlCommand checkVillianMinion = new SqlCommand(checkVillainMinionCode, connection))
            {
                checkVillianMinion.Parameters.AddWithValue("@minionID", minionID);

                int? objectExists = (int?)checkVillianMinion.ExecuteScalar();

                if(objectExists != null)
                {
                    Console.WriteLine($"This Combination of Villan - Minion already exist or minion is server to another Master");
                    return;
                }
            }

            using (SqlCommand insertObject = new SqlCommand(insertMinionVillain, connection))
            {

                insertObject.Parameters.AddWithValue("@villainId", villainID);
                insertObject.Parameters.AddWithValue("@minionId", minionID);

                insertObject.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int CheckVillain(string villainName, SqlConnection connection, string selectVillain)
        {
            using (SqlCommand checkObject = new SqlCommand(selectVillain, connection))
            {
                checkObject.Parameters.AddWithValue("@Name", villainName);

                int? objectExists = (int?)checkObject.ExecuteScalar();

                if (objectExists == null)
                {
                    string insertVillain = "INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)";
                    using (SqlCommand insertObject = new SqlCommand(insertVillain, connection))
                    {
                        insertObject.Parameters.AddWithValue("@villainName", villainName);
                        insertObject.ExecuteNonQuery();
                    }

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                return (int)checkObject.ExecuteScalar();
            }
        }

        private static int CheckMinion(string minionName, int minionAge, SqlConnection connection, int townID, string selectMinion)
        {
            using (SqlCommand checkObject = new SqlCommand(selectMinion, connection))
            {
                checkObject.Parameters.AddWithValue("@Name", minionName);

                int? objectExists = (int?)checkObject.ExecuteScalar();

                if (objectExists == null)
                {
                    string insertMinion = "INSERT INTO Minions(Name, Age, TownId) VALUES(@Name, @age, @townId)";
                    using (SqlCommand insertObject = new SqlCommand(insertMinion, connection))
                    {
                        insertObject.Parameters.AddWithValue("@Name", minionName);
                        insertObject.Parameters.AddWithValue("@age", minionAge);
                        insertObject.Parameters.AddWithValue("@townId", townID);
                        insertObject.ExecuteNonQuery();
                    }
                }

                return (int)checkObject.ExecuteScalar();
            }
        }

        private static int CheckTown(string minionTown, SqlConnection connection, string selectTown)
        {
            using (SqlCommand checkObject = new SqlCommand(selectTown, connection))
            {
                checkObject.Parameters.AddWithValue("@townName", minionTown);

                int? objectExists = (int?)checkObject.ExecuteScalar();

                if (objectExists == null)
                {
                    string insertTown = "INSERT INTO Towns (Name) VALUES (@townName)";
                    using (SqlCommand insertObject = new SqlCommand(insertTown, connection))
                    {
                        insertObject.Parameters.AddWithValue("@townName", minionTown);
                        insertObject.ExecuteNonQuery();
                    }

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                return (int)checkObject.ExecuteScalar();
            }
        }
    }
}
