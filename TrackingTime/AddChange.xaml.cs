using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
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
    /// Логика взаимодействия для AddChange.xaml
    /// </summary>
    public partial class AddChange : Window
    {
        DataSet ds = new DataSet();
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        public AddChange()
        {
            InitializeComponent();
        }

       
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nam.Text == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DataContext db = new DataContext(connectionString);
                Smena change = new Smena()
                {
                    Change_of_employee = nam.Text,
                };
                db.GetTable<Smena>().InsertOnSubmit(change);
                db.SubmitChanges();// Save changes
                MessageBox.Show("Смена Успешно Добавлена. ID = " + change.Id.ToString());
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
            Close();
        }
    }
}
