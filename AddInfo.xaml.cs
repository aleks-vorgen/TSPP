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
		private static bool all_valid = true;

		public AddInfo()
		{
			InitializeComponent();
		}

		private bool Validate()
        {
			if (Surname_textBox.Text == "Фамилия" || Cathedra_textBox.Text == "Кафедра" || Birth_TextBox.Text == "Год рождения" ||
				WasHired_TextBox.Text == "Год трудоустройства" || Rank_TextBox.Text == "Должность" || Position_ComboBox.SelectedIndex == -1)
			{
				return false;
			}
			else
				return true;
		}

		private void AddInfo_Button_Click(object sender, RoutedEventArgs e)
		{
			if (Validate())
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

        private void SelectOnClick(object sender, RoutedEventArgs e)
        {
			TextBox focused = (TextBox)sender;
			focused.Clear();
        }

		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			TextBox box = (TextBox)sender;
			//box.BorderBrush = Brushes.Black;
			if (box.Text == "")
			{
				Surname_textBox.Text = "Фамилия";
				Cathedra_textBox.Text = "Кафедра";
				Birth_TextBox.Text = "Год рождения";
				WasHired_TextBox.Text = "Год трудоустройства";
				Rank_TextBox.Text = "Должность";
			}
		}

		private void Validate_TextInput(object sender, TextChangedEventArgs e)
        {
			TextBox box = (TextBox)sender;
			if (!Regex.IsMatch(box.Text, @"\p{IsCyrillic}+"))
				box.BorderBrush = Brushes.Red;
        }

        

        //private void SelectOnUnfocus(object sender, RoutedEventArgs e)
        //{
        //	TextBox unfocused = (TextBox)sender;
        //}
    }
}
