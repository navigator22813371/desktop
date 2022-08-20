using System;
using System.Activities.Presentation.Model;
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
    /// Логика взаимодействия для DeleteChange.xaml
    /// </summary>
    public partial class DeleteChange : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        string SqlChange = "select * from Change";
        public DeleteChange()
        {
            InitializeComponent();
            BindComboBox(nam, "Change", "сhange_of_employee", SqlChange);
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
                DataContext db = new DataContext(connectionString);
                var deleteChange = db.GetTable<Smena>().First(x => x.Change_of_employee == nam.Text);
                db.GetTable<Smena>().DeleteOnSubmit(deleteChange);
                db.SubmitChanges();
                MessageBox.Show("Goodbay " + deleteChange.Change_of_employee);
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
