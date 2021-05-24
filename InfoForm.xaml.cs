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
using Word = Microsoft.Office.Interop.Word;
using Xceed.Words.NET;
using Xceed.Document.NET;

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

        private void ShowSearchFilter_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchFilter searchFilter = new SearchFilter();
            searchFilter.Show();
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
        private void PrintData(object sender, RoutedEventArgs e)
        { 
            string[] article = new string[20];
            string[] id = new string[20];
            string[] name = new string[20];
            string[] price = new string[20];
            string[] count = new string[20];
            string[] Priceid = new string[20];
            int size = 0;
            int priceSize = 0;

            BindingList<DATA> DatA;
            DatA = new BindingList<DATA>(); // Выделяем динамическую память под переменную привязки данных

            string connector = "server=localhost;user=root;database=range_of_shoes;password=1234;";
            MySqlConnection conn = new MySqlConnection(connector); // Подключаемся к серверу
            conn.Open();

            string sql = "SELECT id, article, name, count, price FROM new_table WHERE id > 0";

            MySqlCommand comman = new MySqlCommand(sql, conn);

            MySqlDataReader reader = comman.ExecuteReader();
            int j = 0;

            while (reader.Read())
            {
                id[j] = reader[0].ToString(); // id
                article[j] = reader[1].ToString(); // article
                name[j] = reader[2].ToString(); // name
                count[j] = reader[3].ToString(); // count
                price[j] = reader[4].ToString(); // price
                j++;
                size++;
            }
            for (int k = 0; k < j; k++)
            {
                if (price[k] == inputer.Text)
                {
                    Priceid[priceSize] = id[k];
                    priceSize++;
                }
            }
            conn.Close();
            if (priceSize > 0)
            {

                string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "Price.docx";

                // создаём документ
                DocX document = DocX.Create(pathDocument);

                // создаём таблицу с 3 строками и 2 столбцами
                Table table = document.AddTable(priceSize + 1, 5);
                // располагаем таблицу по центру
                table.Alignment = Alignment.center;
                // меняем стандартный дизайн таблицы
                table.Design = TableDesign.TableGrid;


                // заполнение ячейки текстом
                table.Rows[0].Cells[0].Paragraphs[0].Append("id").FontSize(18);
                // заполнение ячейки ссылкой

                table.Rows[0].Cells[1].Paragraphs[0].Append("article").FontSize(18);

                table.Rows[0].Cells[2].Paragraphs[0].Append("name").FontSize(18);

                table.Rows[0].Cells[3].Paragraphs[0].Append("count").FontSize(18);

                table.Rows[0].Cells[4].Paragraphs[0].Append("price").FontSize(18);

                int rows = 1;
                for (int i = 0; i < size; i++)
                {
                    for (int b = 0; b < priceSize; b++)
                    {
                        if (id[i] == Priceid[b])
                        {

                            table.Rows[rows].Cells[0].Paragraphs[0].Append(id[i]);

                            table.Rows[rows].Cells[1].Paragraphs[0].Append(article[i]);

                            table.Rows[rows].Cells[2].Paragraphs[0].Append(name[i]);

                            table.Rows[rows].Cells[3].Paragraphs[0].Append(count[i]);

                            table.Rows[rows].Cells[4].Paragraphs[0].Append(price[i]);

                            rows++;

                        }
                    }


                }

                document.InsertParagraph().InsertTableAfterSelf(table);

                // сохраняем документ
                document.Save();


            }

        }
}
