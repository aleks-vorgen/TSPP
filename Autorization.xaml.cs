using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TSPP.DB;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
namespace TSPP
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        private static string login = "admin";
        private static string password = "password";

        private bool AuthenticateUser(string username, string password)
        {
            bool was_username_found=false;
            string query = $"SELECT password, is_worker FROM [UserList] WHERE [username] = '{username}'";
            try
            {
                SqlDataReader reader = TSPP.DB.DB.GetReaderForQuery(query);
                string password_from_db="";
                while (reader.Read())
                {
                    was_username_found = true;
                    password_from_db = reader.GetString(0);
                }
                if (!was_username_found)
                {
                    
                    AlertBox.Content = "Пользователя с таким именем нет";
                    AlertBox.Visibility = System.Windows.Visibility.Visible;
                    LogInField.BorderBrush = Brushes.Red;
                }
                else if (password_from_db != password)
                {
                    AlertBox.Content = "Пароль не совпадает";
                    AlertBox.Visibility = System.Windows.Visibility.Visible;
                }
            } catch (Exception)
            {
            }


            return true;
        }
        public Autorization()
        {
            InitializeComponent();
            AlertBox.Visibility = System.Windows.Visibility.Hidden;
        }

        private void LogInField_TextChanged(object sender, TextChangedEventArgs e)
        {
            LogInField.BorderBrush = Brushes.Black;
        }

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
            AuthenticateUser(LogInField.Text, PasswordField.Password);

            //if (LogInField.Text == login && PasswordField.Password == password)
            //{
            //    InfoForm InfoForm = new InfoForm();
            //    this.Close();
            //    InfoForm.Show();

            //}
        }
    }
}
