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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TSPP
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        static string login;
        static string password;

        private bool AuthenticateUser(string username, string password)
        {
            
            MySqlCommand command = new MySqlCommand();
            string usrnm, pass;
            string commandString = $"SELECT username, password FROM EmployeeList WHERE username={login};";
            MySqlDataReader reader;
            TSPP.Database1DataSet.UserListDataTable data_table = new TSPP.Database1DataSet.UserListDataTable();
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                reader.Read();
                
            }
            catch (Exception)
            {



            }

            return true;
        }
        public Autorization()
        {
            InitializeComponent();
        }

        private void LogInField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            if (LogInField.Text == login && PasswordField.Password == password)
            {
                InfoForm InfoForm = new InfoForm();
                this.Hide();
                InfoForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
=======
            AuthenticateUser(LogInField.Text, PasswordField.Password);

            //if (LogInField.Text == login && PasswordField.Password == password)
            //{
            //    InfoForm InfoForm = new InfoForm();
            //    this.Close();
            //    InfoForm.Show();
                
            //}
>>>>>>> 38fdfe645e2b7ad7455f095500b2932a19fb4218
        }
    }
}
