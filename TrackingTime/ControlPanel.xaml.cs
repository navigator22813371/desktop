using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        

        public ControlPanel()
        {
            InitializeComponent();

            if (Adm.Carent == "admin")
            {
                RegAdmin.IsEnabled = true;
            }
            else
            {
                RegAdmin.IsEnabled = false;
            }

        }
    
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            DeleteEmployee deleteEmployee = new DeleteEmployee();
            deleteEmployee.ShowDialog();
        }

        private void AddPosition_Click(object sender, RoutedEventArgs e)
        {
            AddPosition addGenre = new AddPosition();
            addGenre.ShowDialog();
        }

        private void DeletePosition_Click(object sender, RoutedEventArgs e)
        {
            DeletePosition deletePosition = new DeletePosition();
            deletePosition.ShowDialog();
        }

        private void AddTime_Click(object sender, RoutedEventArgs e)
        {
            AddHourEmpl addHourEmpl = new AddHourEmpl();
            addHourEmpl.ShowDialog();
        }

        private void DeleteTime_Click(object sender, RoutedEventArgs e)
        {
            DeleteHour deleteHour = new DeleteHour();
            deleteHour.ShowDialog();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddChange_Click(object sender, RoutedEventArgs e)
        {
            AddChange addChange = new AddChange();
            addChange.ShowDialog();
        }

        private void DeleteChange_Click(object sender, RoutedEventArgs e)
        {
            DeleteChange deleteChange = new DeleteChange();
            deleteChange.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegUser reg = new RegUser();
            reg.ShowDialog();
        }
    }
}
