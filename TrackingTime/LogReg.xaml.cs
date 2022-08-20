using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для LogReg.xaml
    /// </summary>
    public partial class LogReg : Window
    {
        //public string arrayLog;
        //public string Text
        //{
        //    get
        //    {
        //        return tbLogin.Text;
        //    }
        //    set
        //    {
        //        tbLogin.Text = value;
        //    }
        //}

        public LogReg()
        {
            InitializeComponent();
            
        }


        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
           
            Authorizations authorization = new Authorizations();
            if (authorization.CheckUser(tbLogin.Text, tbPassword.Text))
            {
                Adm.Carent = tbLogin.Text;
                MessageBox.Show("Вы Успешно Авторизованы", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                
                //arrayLog = tbLogin.Text;
                    
            }
            else
            {
                MessageBox.Show("Вы не Авторизованы", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //void SendMail(string fromMailLogin, string fromMailPassword, string toMailLogin)
        //{
        //    MailAddress from = new MailAddress(fromMailLogin, "RegisterNavigator");
        //    MailAddress to = new MailAddress(toMailLogin);
        //    MailMessage mail = new MailMessage(from, to);
        //    mail.Subject = "Успешно зареган";
        //    mail.Body = "Красава успешно зарегался";
        //    mail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    smtp.Credentials = new NetworkCredential(fromMailLogin, fromMailPassword);
        //    smtp.EnableSsl = true;
        //    smtp.Send(mail);
        //}

        //private void reg_Click(object sender, RoutedEventArgs e)
        //{

        //    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Authorize;Integrated Security=True";
        //    string sqlExpression = $"Exec Add_User '{tbLogin.Text}','{tbPassword.Text}'";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(sqlExpression, connection);
        //        int number = command.ExecuteNonQuery();
        //        MessageBox.Show("Пользователь успешно зарегистрирован", number.ToString());
        //    }
        //}
    }
}
