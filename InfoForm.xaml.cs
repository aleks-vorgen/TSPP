using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TSPP
{
    /// <summary>
    /// Логика взаимодействия для InfoForm.xaml
    /// </summary>
    public partial class InfoForm : Window
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TSPP.Database1DataSet EmployeeListDataSet = ((TSPP.Database1DataSet)(this.FindResource("database1DataSet")));
            // Загрузить данные в таблицу EmployeesList. Можно изменить этот код как требуется.
            TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter database1DataSetEmployeesListTableAdapter =
                new TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter();
            database1DataSetEmployeesListTableAdapter.Fill(EmployeeListDataSet.EmployeesList);
            System.Windows.Data.CollectionViewSource employeesListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesListViewSource")));
            employeesListViewSource.View.MoveCurrentToFirst();
            //database1DataSetEmployeesListTableAdapter.Adapter.SelectCommand.       
        }

        private void ShowEmployeeForm_Button_Click(object sender, RoutedEventArgs e)
        {
            AddInfo addInfoForm = new AddInfo();
            addInfoForm.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show(
                "Закрыть приложение?",
                "University",
                MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(1);
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView SelectedRow = (System.Data.DataRowView)employeesListDataGrid.SelectedItem;
            int id = (int)SelectedRow.Row.ItemArray[0];
            string surname = (string)SelectedRow.Row.ItemArray[1];
            uint birth_year = (uint)(int)SelectedRow.Row.ItemArray[2];
            uint was_hired_year = (uint)(int)SelectedRow.Row.ItemArray[3];
            string position = (string)SelectedRow.Row.ItemArray[4];
            string rank = (string)SelectedRow.Row.ItemArray[5];
            string cathedra_name = (string)SelectedRow.Row.ItemArray[7];
            AddInfo EditForm = new AddInfo("Редактирование",id, surname, birth_year, was_hired_year, rank, cathedra_name);
            EditForm.Show();
        }

        private void RetirementExp_MeniItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rank_MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
