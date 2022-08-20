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
    /// Логика взаимодействия для DeletePosition.xaml
    /// </summary>
    public partial class DeletePosition : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        string SqlPosition = "select * from Position";
        public DeletePosition()
        {
            InitializeComponent();
            BindComboBox(nam, "Position", "position_name", SqlPosition);
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
                if (nam.SelectedIndex == -1)
                {
                    MessageBox.Show("Необходимо заполнить все поля", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DataContext db = new DataContext(connectionString);
                var deletePosition = db.GetTable<Position>().First(x => x.Position_name == nam.Text);
                db.GetTable<Position>().DeleteOnSubmit(deletePosition);
                db.SubmitChanges();
                MessageBox.Show("Goodbay " + deletePosition.Position_name);
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
