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
    /// Логика взаимодействия для InfoForm.xaml
    /// </summary>
    public partial class InfoForm : Window
    {
        public InfoForm()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
=======
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TSPP.Database1DataSet database1DataSet = ((TSPP.Database1DataSet)(this.FindResource("database1DataSet")));
            // Загрузить данные в таблицу EmployeesList. Можно изменить этот код как требуется.
            TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter database1DataSetEmployeesListTableAdapter = new TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter();
            database1DataSetEmployeesListTableAdapter.Fill(database1DataSet.EmployeesList);
            System.Windows.Data.CollectionViewSource employeesListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesListViewSource")));
            employeesListViewSource.View.MoveCurrentToFirst();
        }
>>>>>>> 999fbb7b3e09a61ba3a14cf68eec94b215afa21a
    }
}
