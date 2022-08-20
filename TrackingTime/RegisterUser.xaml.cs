//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace TrackingTime
//{
//    /// <summary>
//    /// Логика взаимодействия для RegisterUser.xaml
//    /// </summary>
//    public partial class RegisterUser : Window
//    {
//        public RegisterUser()
//        {
//            InitializeComponent();
//        }

//        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
//        {
//            Application.Current.Shutdown();
//        }

//        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
//        {
//            this.DragMove();
//        }
        
//        private void reg_Click(object sender, RoutedEventArgs e)
//        {

//            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Authorize;Integrated Security=True";
//            string sqlExpression = $"Exec Add_User '{tbLogin.Text}','{tbPassword.Text}'";

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand(sqlExpression, connection);
//                int number = command.ExecuteNonQuery();
//                MessageBox.Show("Пользователь успешно зарегистрирован", number.ToString());
//            }
//        }
//    }
//}
