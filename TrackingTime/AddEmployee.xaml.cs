using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
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
using TrackingTime.Models;

namespace TrackingTime
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        DataSet ds = new DataSet();
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        string SqlPosition = "select * from Position";

        public AddEmployee()
        {
            InitializeComponent();
            BindComboBox(positionEmp, "Employee", "position_name", SqlPosition);
        }

        public void BindComboBox(ComboBox comboBoxName, string table, string name_column, string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, table);
            comboBoxName.ItemsSource = ds.Tables[table].DefaultView;
            comboBoxName.DisplayMemberPath = ds.Tables[table].Columns[name_column].ToString();
            // comboBoxName.SelectedValuePath = ds.Tables[0].Columns["ZoneId"].ToString();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nam.Text == "" || positionEmp.SelectedIndex == -1 || numbers.Text == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (numbers.Text.Length < 16)
                {
                    MessageBox.Show("Необходимо верно заполнить номер телефона", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (numbers.Text.Length == 16)
                {
                    string tel = numbers.Text;
                    char[] num = tel.ToCharArray();
                    if (num[1] != '7')
                    {
                        MessageBox.Show("Телефон должен начинаться +7", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                DataContext db = new DataContext(connectionString);

                DataView dsPos = positionEmp.ItemsSource as DataView;
                int? selectedIdPos = dsPos.Table.Rows[positionEmp.SelectedIndex].ItemArray[0] as int?;


                Employee newEmployee = new Employee()
                {
                    Fio = nam.Text,
                    Position_id = selectedIdPos.GetValueOrDefault(0),
                    Phone = numbers.Text,
                };
                db.GetTable<Employee>().InsertOnSubmit(newEmployee);
                db.SubmitChanges();// Save changes
                MessageBox.Show("Cотрудник Успешно Добавлен. ID = " + newEmployee.Id.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// выставляет + и - для номера телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numbers_KeyDown(object sender, KeyEventArgs e)
        {
            
            string text = numbers.Text.Replace("+", "").Replace("-", "");
            if (text.Length > 0)
            {
                text = text.Insert(0, "+");
                numbers.Text = text;
                numbers.CaretIndex = numbers.Text.Length;
            }
            if (text.Length > 1)
            {
                text = text.Insert(2, "-");
                numbers.Text = text;
                numbers.CaretIndex = numbers.Text.Length;
            }
            if (text.Length > 5)
            {
                text = text.Insert(6, "-");
                numbers.Text = text;
                numbers.CaretIndex = numbers.Text.Length;
            }
            if (text.Length > 9)
            {
                text = text.Insert(10, "-");
                numbers.Text = text;
                numbers.CaretIndex = numbers.Text.Length;
            }
            if (text.Length > 12)
            {
                text = text.Insert(13, "-");
                numbers.Text = text;
                numbers.CaretIndex = numbers.Text.Length;
            }

        }
        
   /// <summary>
   /// Запрет Ввода Букв(Only numbers)
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
        private void numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
