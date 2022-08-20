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
    /// Логика взаимодействия для AddHourEmpl.xaml
    /// </summary>
    public partial class AddHourEmpl : Window
    {
        DataSet ds = new DataSet();
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        string SqlPosition = "select * from Position";
        string SqlEmployee = "select * from Employee";
        string SqlChange = "select * from Change";
        public AddHourEmpl()
        {
            InitializeComponent();
            BindComboBox(positionEmp, "Position", "position_name", SqlPosition);
            BindComboBox(nam, "Employee", "fio", SqlEmployee);
            BindComboBox(smena, "Change", "сhange_of_employee", SqlChange);
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nam.Text == "" || positionEmp.SelectedIndex == -1 || smena.SelectedIndex == -1 || hour.Text == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DataContext db = new DataContext(connectionString);

                DataView dsEmpl = nam.ItemsSource as DataView;
                int? selectedIdEmpl = dsEmpl.Table.Rows[nam.SelectedIndex].ItemArray[0] as int?;

                DataView dsPos = positionEmp.ItemsSource as DataView;
                int? selectedIdPos = dsPos.Table.Rows[positionEmp.SelectedIndex].ItemArray[0] as int?;

                DataView dsChange = smena.ItemsSource as DataView;
                int? selectedIdChange = dsChange.Table.Rows[smena.SelectedIndex].ItemArray[0] as int?;
                WorkHours workHours = new WorkHours()
                {
                    Employee_id = selectedIdEmpl.GetValueOrDefault(0),
                    Position_id = selectedIdPos.GetValueOrDefault(0),
                    Change_id = selectedIdChange.GetValueOrDefault(0),
                    Number_of_hours = Convert.ToInt32(hour.Text),
                    Date = DateTime.Now.Date,
                };
                db.GetTable<WorkHours>().InsertOnSubmit(workHours);
                db.SubmitChanges();// Save changes
                MessageBox.Show("Часы Сотруднику Успешно Добавлены. ID = " + workHours.Id.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
