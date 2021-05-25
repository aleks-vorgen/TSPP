﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace TSPP
{
    public partial class Registration : Window
    {
        private static Dictionary<string, bool> validity = new Dictionary<string, bool>(3);
        private static bool can_create_admins;
        public Registration(bool _can_create_admins)
        {
            InitializeComponent();
            can_create_admins = _can_create_admins;
            if (!can_create_admins)
                IsAdminCheck.IsEnabled = false;
            else
                this.Title = "Adding user";
        }
        private void validityDictInit()
        {
            validity[LoginField.Name] = false;
            validity[PasswordField.Name] = false;
            validity[ConfirmPasswordField.Name] = false;
        }
        private static void ValidateUsername(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (!IsLatin(box.Text))
            {
                validity[box.Name] = false;
                box.BorderBrush = Brushes.Red;
            }
            if (box.Text.Length > 8)
            {
                validity[box.Name] = false;
                box.BorderBrush = Brushes.Red;
                System.Windows.Forms.MessageBox.Show(
                "Логин должен быть до 8 символов включительно",
                "",
                System.Windows.Forms.MessageBoxButtons.OK);
            }
            box.BorderBrush = Brushes.Gray;
            validity[box.Name] = true;
        }
        private static void ValidatePassword(object sender, RoutedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;
            if (!IsLatin(box.Password))
            {
                validity[box.Name] = false;
                box.BorderBrush = Brushes.Red;
            }
            if (box.Password.Length > 8)
            {
                validity[box.Name] = false;
                box.BorderBrush = Brushes.Red;
                System.Windows.Forms.MessageBox.Show(
                "Пароль должен быть до 8 символов включительно",
                "",
                System.Windows.Forms.MessageBoxButtons.OK);
            }
        }
        private void Register(object sender, RoutedEventArgs e)
        { 
            foreach(bool value in validity.Values)
                if (!value)
                {
                    System.Windows.Forms.MessageBox.Show(
                 "Некоторые поля имеют ошибки ввода",
                 "",
                 System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }
            if (PasswordField.Password != ConfirmPasswordField.Password)
            {
                System.Windows.Forms.MessageBox.Show(
                 "Пароли не совпадают",
                 "",
                 System.Windows.Forms.MessageBoxButtons.OK);
                PasswordField.BorderBrush = ConfirmPasswordField.BorderBrush = Brushes.Red;
                return;
            }
            try
            {
                TSPP.DB.DB.AddUser(LoginField.Text.Trim(), PasswordField.Password.Trim(), (bool)(can_create_admins ? IsAdminCheck.IsChecked : false));
                System.Windows.Forms.MessageBox.Show(
                 "Вы успешно зарегистрировались",
                 "",
                 System.Windows.Forms.MessageBoxButtons.OK);
                Autorization autorization = new Autorization();
                autorization.Show();
            } catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show(
                 "При регистрации произошла непредвиденная ошибка",
                 "",
                 System.Windows.Forms.MessageBoxButtons.OK);
            }
        }
        static private bool IsLatin(string sstring)
        {
            return Regex.IsMatch(sstring, @"\p{IsBasicLatin}");
        }
    }
}