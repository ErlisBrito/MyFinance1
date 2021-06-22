using System.Data;
using MySql.Data.MySqlClient;

namespace MyFinance1.Util
{
    public class DAL
    {
        private static string serve = "localhost";
        private static string database = "Financeiro";
        private static string user = "root";
        private static string password = "root";
        private string connectionString = $"Server={serve};Database={database};Uid={user};Pwd={password};";
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        //executa selects
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter ad = new MySqlDataAdapter(command);
            ad.Fill(dataTable);
            return dataTable;
        }

        // Executa INSERTs, UPDATEs, DELETEs
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}


