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
    /// Логика взаимодействия для DeleteHour.xaml
    /// </summary>
    public partial class DeleteHour : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        string SqlPosition = "select * from Position";
        string SqlEmployee = "select * from Employee";
        string SqlChange = "select * from Change";
        public DeleteHour()
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
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataView dsEmpl = nam.ItemsSource as DataView;
                int? selectedIdEmpl = dsEmpl.Table.Rows[nam.SelectedIndex].ItemArray[0] as int?;

                DataView dsPos = positionEmp.ItemsSource as DataView;
                int? selectedIdPos = dsPos.Table.Rows[positionEmp.SelectedIndex].ItemArray[0] as int?;

                DataView dsChange = smena.ItemsSource as DataView;
                int? selectedIdChange = dsChange.Table.Rows[smena.SelectedIndex].ItemArray[0] as int?;

                if (nam.SelectedIndex == -1 || positionEmp.SelectedIndex == -1 || smena.SelectedIndex == -1 || cal.SelectedDate == null)
                {
                    MessageBox.Show("Необходимо заполнить все поля", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DataContext db = new DataContext(connectionString);
                var deleteWorkHours = db.GetTable<WorkHours>().First(x => x.Employee_id == selectedIdEmpl && x.Position_id == selectedIdPos && x.Change_id == selectedIdChange && x.Date == cal.SelectedDate.GetValueOrDefault());
                db.GetTable<WorkHours>().DeleteOnSubmit(deleteWorkHours);
                db.SubmitChanges();
                MessageBox.Show("Goodbay " + deleteWorkHours.Employee_id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
