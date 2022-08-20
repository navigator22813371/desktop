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
    /// Логика взаимодействия для AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Window
    {
        DataSet ds = new DataSet();
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";
        public AddPosition()
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
                Position newPosition = new Position()
                {
                    Position_name = nam.Text,
                };
                db.GetTable<Position>().InsertOnSubmit(newPosition);
                db.SubmitChanges();// Save changes
                MessageBox.Show("Должность Успешно Добавлена. ID = " + newPosition.Id.ToString());
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
