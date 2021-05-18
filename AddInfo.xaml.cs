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
		public AddInfo()
		{
			InitializeComponent();
			ValidityDictInit();
		}
		static public void CheckTextBox(TextBox box, string default_box_name)
		{
			if (box.Text == default_box_name || !IsCyrillic(box.Text))
			{
				box.BorderBrush = Brushes.Red;
				return;
			}
			box.BorderBrush = Brushes.Gray;
		}

		private static Dictionary<string, bool> validity = new Dictionary<string, bool>(6);

		private void ValidityDictInit()
        {
			validity.Add(Surname_textBox.Name, false);
			validity.Add(Cathedra_textBox.Name, false);
			validity.Add(Birth_TextBox.Name, false);
			validity.Add(WasHired_TextBox.Name, false);
			validity.Add(Rank_TextBox.Name, false);
			validity.Add(Position_ComboBox.Name, false);
        }



		private void ValidateComboBox(object sender, SelectionChangedEventArgs e)
		{
			ComboBox box = (ComboBox)sender;
			if (box.SelectedIndex == -1) { }
			else
				return;
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
				return;
			}
			box.BorderBrush = Brushes.Gray;
		}

    }
}
