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
                "Unoversity",
                MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Environment.Exit(1);
        }
    }
}
