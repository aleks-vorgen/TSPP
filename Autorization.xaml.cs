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
            string query = "";
            DB.DB.SelectQuery(query);

            
            try
            {
                
                
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
