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
            TSPP.Database1DataSet dataset = ((TSPP.Database1DataSet)(this.FindResource("database1DataSet")));
            TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter adapter =
                new TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter();
            Database1DataSet.UserListDataTable table = (Database1DataSet.UserListDataTable)dataset.Tables["UserList"];
            TSPP.Database1DataSet.UserListRow[] foundRows;
            foundRows = (Database1DataSet.UserListRow[])table.Select();
            TSPP.Database1DataSet.UserListRow[] query1 = (Database1DataSet.UserListRow[])dataset.UserList.Select();
            TSPP.Database1DataSet.UserListRow[] query2 = (Database1DataSet.UserListRow[])dataset.UserList.Select($"username = {login}");
            //Всегда будет возвращать 1 строку, но так как это частный случай, то кастим тип
            TSPP.Database1DataSet.UserListRow line = query1[0]; //и берём первое значение из массива (и единственное)
            string usrnm, pass;

            TSPP.Database1DataSet.UserListDataTable data_table = new TSPP.Database1DataSet.UserListDataTable();
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
