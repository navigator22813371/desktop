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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackingTime.Models;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace TrackingTime
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<Employee> employee = new List<Employee>();
        //public Employee SelectedEmployee { get; set; }
        DataSet ds = new DataSet();

        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TimeTracking;Integrated Security=True";

        string SqlEmployee = "select date AS[Дата Добавления], fio AS[ФИО], position_name AS[Должность], phone AS[Номер],сhange_of_employee AS[Cмена], number_of_hours AS[Часы]"+
                              " from WorkHours" +
                              " JOIN Change"+
                              " ON Change.id = WorkHours.change_id"+
                              " JOIN Employee"+
                              " ON Employee.id = WorkHours.employee_id"+
                              " JOIN Position"+
                              " ON Position.id = WorkHours.position_id";

        string SqlOtchet = "SELECT * FROM OtchetYear";

        public MainWindow()
        {
            InitializeComponent();
            ButtonLoad_Click_1(null, null);
        }
     
        private void ButtonLoad_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                   
                    SqlDataAdapter adapterEmployee = new SqlDataAdapter(SqlEmployee, connection);
                    

                    ds.Clear();

                    adapterEmployee.Fill(ds, "Employee");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            switch (index)
            {
                case 0:
                    dgMain.ItemsSource = ds.Tables["Employee"].DefaultView;
                    break;
                case 1:
                    DataTable table = new DataTable();


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(SqlOtchet, connection))
                        {
                            table.Load(command.ExecuteReader());
                        }

                        connection.Close();
                    }

                    
                    dgMain.ItemsSource = table.DefaultView;
                    break;
                case 2:
                    //dgMain.Background = Brushes.CadetBlue;
                    //dgMain.ItemsSource = ds.Tables["Publishing_houses"].DefaultView;
                    break;
                case 3:
                    //dgMain.Background = Brushes.DarkBlue;
                    //dgMain.ItemsSource = ds.Tables["Genres"].DefaultView;
                    break;
                case 4:
                    dgMain.Background = Brushes.Firebrick;
                    break;
                case 5:
                    dgMain.Background = Brushes.Gainsboro;
                    break;
                case 6:
                    dgMain.Background = Brushes.HotPink;
                    break;
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext db = new DataContext(connectionString);
                var filterQuery = from workHours in db.GetTable<WorkHours>()
                                  join change in db.GetTable<Smena>()
                                  on workHours.Change_id equals change.Id
                                  join employee in db.GetTable<Employee>()
                                  on workHours.Employee_id equals employee.Id
                                  join position in db.GetTable<Position>()
                                  on workHours.Position_id equals position.Id
                                  where employee.Fio.Contains(tbSearch.Text)
                                  select new
                                  {
                                      //Дата_Добавления = workHours.Date,
                                      ФИО = employee.Fio,
                                      Должность = position.Position_name,
                                      Номер = employee.Phone,
                                      Cмена = change.Change_of_employee,
                                      Часы = workHours.Number_of_hours
                                  };
                if (cmbColors.SelectedIndex == 0)
                {
                    filterQuery = from workHours in db.GetTable<WorkHours>()
                                  join change in db.GetTable<Smena>()
                                  on workHours.Change_id equals change.Id
                                  join employee in db.GetTable<Employee>()
                                  on workHours.Employee_id equals employee.Id
                                  join position in db.GetTable<Position>()
                                  on workHours.Position_id equals position.Id
                                  where employee.Fio.Contains(tbSearch.Text)
                                  select new
                                  {
                                      //Дата_Добавления = workHours.Date,
                                      ФИО = employee.Fio,
                                      Должность = position.Position_name,
                                      Номер = employee.Phone,
                                      Cмена = change.Change_of_employee,
                                      Часы = workHours.Number_of_hours
                                  };
                }
                else if (cmbColors.SelectedIndex == 1)
                {
                    filterQuery = from workHours in db.GetTable<WorkHours>()
                                  join change in db.GetTable<Smena>()
                                  on workHours.Change_id equals change.Id
                                  join employee in db.GetTable<Employee>()
                                  on workHours.Employee_id equals employee.Id
                                  join position in db.GetTable<Position>()
                                  on workHours.Position_id equals position.Id
                                  where position.Position_name.Contains(tbSearch.Text)
                                  select new
                                  {
                                      //Дата_Добавления = workHours.Date,
                                      ФИО = employee.Fio,
                                      Должность = position.Position_name,
                                      Номер = employee.Phone,
                                      Cмена = change.Change_of_employee,
                                      Часы = workHours.Number_of_hours
                                  };
                }
                else if (cmbColors.SelectedIndex == 2)
                {
                    filterQuery = from workHours in db.GetTable<WorkHours>()
                                  join change in db.GetTable<Smena>()
                                  on workHours.Change_id equals change.Id
                                  join employee in db.GetTable<Employee>()
                                  on workHours.Employee_id equals employee.Id
                                  join position in db.GetTable<Position>()
                                  on workHours.Position_id equals position.Id
                                  where change.Change_of_employee.Contains(tbSearch.Text)
                                  select new
                                  {
                                      //Дата_Добавления = workHours.Date,
                                      ФИО = employee.Fio,
                                      Должность = position.Position_name,
                                      Номер = employee.Phone,
                                      Cмена = change.Change_of_employee,
                                      Часы = workHours.Number_of_hours
                                  };
                }
                //else if (cmbColors.SelectedIndex == 3)
                //{
                //    filterQuery = from workHours in db.GetTable<WorkHours>()
                //                  join change in db.GetTable<Smena>()
                //                  on workHours.Change_id equals change.Id
                //                  join employee in db.GetTable<Employee>()
                //                  on workHours.Employee_id equals employee.Id
                //                  join position in db.GetTable<Position>()
                //                  on workHours.Position_id equals position.Id
                //                  where workHours.Number_of_hours.Contains(tbSearch.Text)
                //                  select new
                //                  {
                //                      //Дата_Добавления = workHours.Date,
                //                      ФИО = employee.Fio,
                //                      Должность = position.Position_name,
                //                      Номер = employee.Phone,
                //                      Cмена = change.Change_of_employee,
                //                      Часы = workHours.Number_of_hours
                //                  };
                //}
                dgMain.ItemsSource = filterQuery;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            ControlPanel controlPanel = new ControlPanel();
            //LogReg log = new LogReg();
            //if (log.arrayLog == "admin")
            //{
            //    controlPanel.Active();
            //}
            
            controlPanel.ShowDialog();
        }
        

        private void Print_Click_1(object sender, RoutedEventArgs e)
        {

            PrintDialog print1 = new PrintDialog();

            if (print1.ShowDialog() == true)
            {


                PrintDG print = new PrintDG();
                print.PrintDataGrid(null, dgMain, null, print1);
             
            }

            

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = dgMain;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String Clipboardresult = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            StreamWriter swObj = new StreamWriter("exportToExcel.csv");
            swObj.WriteLine(Clipboardresult);
            swObj.Close();
            Process.Start("exportToExcel.csv");

           
        }

   

        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Panel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Contact_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Project Сreator: NAVIGATOR", "CONTACT", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
