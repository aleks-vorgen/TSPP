using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace TSPP.DB
{
    class DB
    {
        public static SqlConnection Connect()
        {
            string cn_string = Properties.Settings.Default.constr; //получаем строку для подключения из конфига
            SqlConnection connection = new SqlConnection(cn_string);
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            return connection;
        }

        public static SqlDataReader GetReaderForQuery(string query)
        {
            SqlConnection connection = Connect();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static void Close_DB_Connection()
        {
            string cn_String = Properties.Settings.Default.constr;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }

        public static void InsertEmployee(string surname, uint birth_year, uint was_hired_year, string position,
            string rank, uint retirement_exp, string cathedra_name)
        {
            SqlConnection connection = Connect();
            string query = "INSERT INTO [EmployeesList] ([surname], [birth_year], [was_hired_year], [position], [rank], "
                + $"[retirement_exp], [cathedra_name]) VALUES (N'{surname}', {birth_year},{was_hired_year}, N'{position}', N'{rank}', {retirement_exp}, N'{cathedra_name}');";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        public static void UpdateEmployee(int id, string surname, uint birth_year, uint was_hired_year, string position,
            string rank, uint retirement_exp, string cathedra_name)
        {
            SqlConnection connection = Connect();
            string query = "UPDATE [EmployeesList]" +
                $" SET [surname]=N'{surname}', [birth_year] = {birth_year}, [was_hired_year] = {was_hired_year}, [position] = N'{position}', [rank] = N'{rank}',"
                + $" [retirement_exp] = {retirement_exp}, [cathedra_name] = N'{cathedra_name}'" +
                $" WHERE [id] = {id}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        public static bool CheckIfUserExists(string username)
        {
            SqlDataReader reader = GetReaderForQuery($"SELECT username FROM [UserList] WHERE [username] = '{username}';");
            bool if_already_exists = false;
            while (reader.Read())
            {
                try
                {
                    string usrnm = reader.GetString(0);
                }
                catch (Exception)
                {
                    return false;
                }
                if_already_exists = true;
            }
            return if_already_exists;
        }

        public static bool AddUser(string username, string password, bool is_worker)
        {
            if (CheckIfUserExists(username))
                return false;
            SqlConnection connection = Connect();
            string query = "INSERT INTO [UserList] ([username], [password], [is_worker])"
                + $" VALUES ('{username}', '{password}', {(is_worker ? 1 : 0)});";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            return true;
        }
    }
}
