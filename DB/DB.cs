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
            string query = "INSERT INTO [EmployeeList] ([surname], [birth_year], [was_hired_year], [position], [rank], "
                + $"[retirement_exp], [carthedra_name] VALUES ({surname}, {birth_year},{was_hired_year}, {position}, {rank}, {retirement_exp}, {cathedra_name})";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        public static void AddUser(string username, string password, bool is_worker)
        {
            SqlConnection connection = Connect();
            string query = "INSERT INTO [UserList] ([username], [password], [is_worker]"
                + $" VALUES ({username}, {password},{is_worker}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
