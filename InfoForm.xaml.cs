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
using System.Drawing;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;
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
            TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter database1DataSetEmployeesListTableAdapter =
                new TSPP.Database1DataSetTableAdapters.EmployeesListTableAdapter();
            database1DataSetEmployeesListTableAdapter.Fill(EmployeeListDataSet.EmployeesList);
            System.Windows.Data.CollectionViewSource employeesListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesListViewSource")));
            employeesListViewSource.View.MoveCurrentToFirst(); 
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
            AddInfo EditForm = new AddInfo("Редактирование", id, surname, birth_year, was_hired_year, rank, cathedra_name);
            EditForm.Show();
        }
        private void PrintData(object sender, RoutedEventArgs e)
        {
            string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "Отчёт.docx";
            // создаём документ
            DocX document = DocX.Create(pathDocument);
            int size = 0;
            SqlDataReader reader = DB.DB.GetReaderForQuery("SELECT count(*) FROM [EmployeesList];");
            while (reader.Read())
                size = reader.GetInt32(0);
            Xceed.Document.NET.Table table = document.AddTable(size + 1, 7);
            // располагаем таблицу по центру
            table.Alignment = Alignment.center;
            // меняем стандартный дизайн таблицы
            table.Design = TableDesign.TableGrid;

            // заполнение ячейки текстом
            table.Rows[0].Cells[0].Paragraphs[0].Append("Фамилия").FontSize(18);
            table.Rows[0].Cells[1].Paragraphs[0].Append("Год рождения").FontSize(18);
            table.Rows[0].Cells[2].Paragraphs[0].Append("Нанят").FontSize(18);
            table.Rows[0].Cells[3].Paragraphs[0].Append("Звание").FontSize(18);
            table.Rows[0].Cells[4].Paragraphs[0].Append("Должность").FontSize(18);
            table.Rows[0].Cells[5].Paragraphs[0].Append("Пенсионный стаж").FontSize(18);
            table.Rows[0].Cells[6].Paragraphs[0].Append("Кафедра").FontSize(18);

            SqlDataReader reader2 = DB.DB.GetReaderForQuery("SELECT * FROM [EmployeesList];");
            int id;
            string surname;
            uint birth_year;
            uint was_hired_year;
            string position;
            string rank;
            uint retirement_exp;
            string cathedra_name;
            int row = 1;
            while (reader2.Read())
            {
                id = reader2.GetInt32(0);
                surname = reader2.GetString(1);
                birth_year = (uint)reader2.GetInt32(2);
                was_hired_year = (uint)reader2.GetInt32(3);
                position = reader2.GetString(4);
                rank = reader2.GetString(5);
                retirement_exp = (uint)reader2.GetInt32(6);
                cathedra_name = reader2.GetString(7);

                table.Rows[row].Cells[0].Paragraphs[0].Append(surname);

                table.Rows[row].Cells[1].Paragraphs[0].Append(Convert.ToString(birth_year));

                table.Rows[row].Cells[2].Paragraphs[0].Append(Convert.ToString(was_hired_year));

                table.Rows[row].Cells[3].Paragraphs[0].Append(position);

                table.Rows[row].Cells[4].Paragraphs[0].Append(rank);

                table.Rows[row].Cells[5].Paragraphs[0].Append(Convert.ToString(retirement_exp));

                table.Rows[row].Cells[6].Paragraphs[0].Append(cathedra_name);
            }
            document.InsertParagraph().InsertTableAfterSelf(table);
            try
            {
                document.Save();
            } catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show(
                "Произошла ошибка при сохранении.",
                "Неудача",
                System.Windows.Forms.MessageBoxButtons.OK);
            }
            System.Windows.Forms.MessageBox.Show(
                "Отчёт успешно сгенерирован.",
                "Успех",
                System.Windows.Forms.MessageBoxButtons.OK);
        }
        private void RetirementExp_MeniItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Rank_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string rank = "";
            while (rank == "" || rank == "Звание")
            {
                rank = Interaction.InputBox("Введите звание", "", "Звание");
                if (rank == "" || rank == "Звание")
                    System.Windows.Forms.MessageBox.Show(
                "Ошибка ввода",
                "Некорректный ввод",
                System.Windows.Forms.MessageBoxButtons.OK);
            }
            
        }

        private void DeleteEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                System.Data.DataRowView SelectedRow = (System.Data.DataRowView)employeesListDataGrid.SelectedItem;
                int id = (int)SelectedRow.Row.ItemArray[0];
                SqlDataReader reader = DB.DB.GetReaderForQuery($"DELETE FROM [EmployeesList] WHERE id = {id}");
                System.Windows.Forms.MessageBox.Show(
                    "Пользователь удалён.",
                    "Успех",
                    System.Windows.Forms.MessageBoxButtons.OK);
            } catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show(
                   "Произошла ошибка.",
                    "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK);
            }
            
        }
    }
}
