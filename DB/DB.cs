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

        public static System.Data.DataRow SelectQuery(string query)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                TSPP.Database1DataSet.UserListDataTable result = new Database1DataSet.UserListDataTable();
                TSPP.Database1DataSet.UserListRow row = result.NewUserListRow();
                int i = 0;
                while (reader.Read())
                {
                    row.Id = (int)reader.GetValue(0);
                    row.username = (string)reader.GetValue(0);
                    row.password = (string)reader.GetValue(0);
                    row.is_worker = (bool)reader.GetValue(0);
                }
                return row;
            }
            catch (Exception)
            {
                return null;  
            }
        }
        public static void Close_DB_Connection()
        {
            string cn_String = Properties.Settings.Default.constr;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }
    }
}
