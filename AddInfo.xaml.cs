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
	/// Логика взаимодействия для AddInfo.xaml
	/// </summary>
	public partial class AddInfo : Window
	{
		public AddInfo()
		{
			InitializeComponent();
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
			Position_ComboBox.Text = "Звание";
		}

		private void AddInfo_CancleButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
