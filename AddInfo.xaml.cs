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
using System.Text.RegularExpressions;

namespace TSPP
{
    /// <summary>
    /// Логика взаимодействия для AddInfo.xaml
    /// </summary>
    public partial class AddInfo : Window
    {
        private static bool all_valid = false;
        private static readonly TextBox[] textBoxList;

        public AddInfo()
        {
            InitializeComponent();
        }
        static public void CheckTextBox(TextBox box, string default_box_name)
        {
            if (box.Text == default_box_name || !IsCyrillic(box.Text))
            {
                box.BorderBrush = Brushes.Red;
                all_valid = false;
                return;
            }
            box.BorderBrush = Brushes.Gray;
        }
        private void ValidateTextBox(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Name == "Surname_textBox")
            {
                CheckTextBox(box, "Surname_textBox");
            }
            if (box.Name == "Cathedra_textBox")
            {
                CheckTextBox(box, "Cathedra_textBox");
            }
            if (box.Name == "Rank_TextBox")
            {
                CheckTextBox(box, "Rank_TextBox");
            }
        }

        private void AddInfo_Button_Click(object sender, RoutedEventArgs e)
        {
            if (all_valid)
                MessageBox.Show("Одно или несколько полей не заполнено", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else { }

        }

        private void AddInfo_ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Surname_textBox.Text = "Фамилия";
            Cathedra_textBox.Text = "Кафедра";
            Birth_TextBox.Text = "Год рождения";
            WasHired_TextBox.Text = "Год трудоустройства";
            Rank_TextBox.Text = "Должность";
        }

        private void AddInfo_CancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearOnClickIfDefault(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Name == "Surname_textBox")
            {
                if (box.Text == "Фамилия")
                    box.Clear();
                return;
            }
            if (box.Name == "Cathedra_textBox")
            {
                if (box.Text == "Кафедра")
                    box.Clear();
                return;
            }
            if (box.Name == "Birth_TextBox")
            {
                if (box.Text == "Год рождения")
                    box.Clear();
                return;
            }
            if (box.Name == "WasHired_TextBox")
            {
                if (box.Text == "Год трудоустройства")
                    box.Clear();
                return;
            }
            if (box.Name == "Rank_TextBox")
            {
                if (box.Text == "Должность")
                    box.Clear();
                return;
            }
            box.Clear();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Text == "")
            {
                if (box.Name == "Surname_textBox")
                {
                    Surname_textBox.Text = "Фамилия";
                    return;
                }
                if (box.Name == "Cathedra_textBox")
                {
                    Cathedra_textBox.Text = "Кафедра";
                    return;
                }
                if (box.Name == "Birth_TextBox")
                {
                    Birth_TextBox.Text = "Год рождения";
                    return;
                }
                if (box.Name == "WasHired_TextBox")
                {
                    WasHired_TextBox.Text = "Год трудоустройства";
                    return;
                }
                if (box.Name == "Rank_TextBox")
                {
                    Rank_TextBox.Text = "Должность";
                    return;
                }
            }
            ValidateTextBox(box, e);
        }

        static private bool IsCyrillic(string sstring)
        {
            return Regex.IsMatch(sstring, @"\p{IsCyrillic}");
        }

        private void CheckIfNumbers(object sender, TextChangedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            uint value;
            if (box.Name == "WasHired_TextBox" && (box.Text == "Год трудоустройства" || box.Text == ""))
                return;
            if (box.Name == "Birth_TextBox" && (box.Text == "Год рождения" || box.Text == ""))
                return;
            if (!UInt32.TryParse(box.Text, out value) || value < 0)
            {
                box.BorderBrush = Brushes.Red;
                all_valid = false;
                return;
            }
            box.BorderBrush = Brushes.Gray;
            all_valid = true;
        }
    }
}
