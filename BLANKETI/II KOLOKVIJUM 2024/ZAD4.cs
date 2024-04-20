using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "[konekcioni string]";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT IME, PREZIME " +
                         "FROM ZAPOSLENI " +
                         "JOIN RADNO_MESTO ON ZAPOSLENI.JMBG = RADNO_MESTO.ZJMBG " +
                         "WHERE RADNO_MESTO.DATUMDO IS NULL " +
                         "AND RADNO_MESTO.IDK = @IDK " +
                         "AND RADNO_MESTO.POZICIJA = 'Prodavac';";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@IDK", connectionString);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["IME"] + " " + reader["PREZIME"]);
                    }
                }
            }
        }
    }
}
