﻿using System;
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
        private string GetPassword(string username)
        {
            bool was_username_found = false;
            string query = $"SELECT password, is_worker FROM [UserList] WHERE [username] = '{username}'";
            string password_from_db = "";
            try
            {
                SqlDataReader reader = TSPP.DB.DB.GetReaderForQuery(query);
                while (reader.Read())
                {
                    was_username_found = true;
                    password_from_db = reader.GetString(0);
                    password_from_db = password_from_db.Trim();
                }
                if (!was_username_found)
                {
                    AlertBox.Content = "Пользователя с таким именем не существует";
                    AlertBox.Visibility = System.Windows.Visibility.Visible;
                    LogInField.BorderBrush = Brushes.Red;
                    return null;
                }
            }
            catch (Exception)
            {
                AlertBox.Content = "Произошла непредвиденная ошибка";
                AlertBox.Visibility = System.Windows.Visibility.Visible;
                return null;
            }
            return password_from_db;
        }
        private void AuthenticateUser(string username, string password)
        {
            string password_from_db = GetPassword(username);
            if (password != password_from_db)
            {
                AlertBox.Content = "Пароль не совпадает";
                AlertBox.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                InfoForm infoForm = new InfoForm();
                this.Close();
                infoForm.Show();
            }

        }
        public Autorization()
        {
            InitializeComponent();
            AlertBox.Visibility = System.Windows.Visibility.Hidden;
            LogInField.Focus();
        }

        private void LogInField_TextChanged(object sender, TextChangedEventArgs e)
        {
            LogInField.BorderBrush = Brushes.Black;
        }

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
            AuthenticateUser(LogInField.Text.Trim(), PasswordField.Password.Trim());
        }

        private void PasswordField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AuthenticateUser(LogInField.Text.Trim(), PasswordField.Password.Trim());
            }
        }
    }
}