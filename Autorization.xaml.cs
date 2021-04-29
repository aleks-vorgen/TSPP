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
        public Autorization()
        {
            //InitializeComponent();
        }

        const string login = "it91";
        const string password = "it-91";

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if(LogInField.Text != login && PasswordField.Password != password)
            {
                MessageBox.Show("Логин или пароль не верный");
            }
            else
            {
                
                MainWindow mainWindow = new MainWindow();
                this.Hide();    //закрыть форму авторизации
                mainWindow.Show();  //Показать InfoForm
            }
        }

        private void LogInField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
