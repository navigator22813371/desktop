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
    /// Логика взаимодействия для DeleteEmployee.xaml
    /// </summary>
    public partial class DeleteEmployee : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        string SqlEmployee = "select * from Employee";
        public DeleteEmployee()
        {
            InitializeComponent();
            BindComboBox(nam, "Employee", "fio", SqlEmployee);
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
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nam.Text == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DataContext db = new DataContext(connectionString);
                var deleteEmployee = db.GetTable<Employee>().First(x => x.Fio == nam.Text);
                db.GetTable<Employee>().DeleteOnSubmit(deleteEmployee);
                db.SubmitChanges();
                MessageBox.Show("Goodbay " + deleteEmployee.Fio);
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
    }
}
