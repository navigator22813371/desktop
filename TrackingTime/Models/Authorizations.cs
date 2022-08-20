using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrackingTime.Models
{
    public class Authorizations
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Authorize;Integrated Security=True";

        const string CheckUserProcedure = "Select dbo.CheckUser(@login, @password)";
        public bool CheckUser(string login, string password)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(CheckUserProcedure, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@login", login);
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    /*
                                        SqlParameter p1 = sqlCommand.CreateParameter();
                                        p1.ParameterName = "@login";
                                        p1.Value = login;

                                        SqlParameter p2 = sqlCommand.CreateParameter();
                                        p2.ParameterName = "@password";
                                        p2.Value = password;

                                        sqlCommand.Parameters.Add(p1);
                                        sqlCommand.Parameters.Add(p2);

                                        //sqlCommand.CommandType = CommandType.StoredProcedure;
                                        */

                    var res = sqlCommand.ExecuteScalar();
                    result = (bool)res;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return result;
        }


    }
}
