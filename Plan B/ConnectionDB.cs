using System.Data;
using Npgsql;

namespace Plan_B
{
    public class ConnectionDB
    {
        //This functions is a chain that is used to connect with the data base
        private static string host = "Localhost",
            database = "ProyectoFinal",
            UserId = "postgres",
            password = "natalia.99";

        //Function to connect the data base
        private static string sConnection =
            $"Server={host};Port=5432;User Id={UserId};Password={password};Database={database};";

        //Function that realize changes in the game
        public static DataTable ExecuteQuery(string query)
        {
            //connection
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            //Tables group
            DataSet ds = new DataSet();
            
            connection.Open();
            
            //Executes a query
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query,connection);
            //fill the dataset
            da.Fill(ds);
            
            connection.Close();

            return ds.Tables[0];
        }

        //Function that realize changes in the data base, but are not showing in the game
        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            
            connection.Open();
            
            //Executes a non query
            NpgsqlCommand command = new NpgsqlCommand(act,connection);
            command.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}