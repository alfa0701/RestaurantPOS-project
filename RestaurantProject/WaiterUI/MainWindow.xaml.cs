using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WaiterUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(this.txtId.Text) | string.IsNullOrEmpty(this.txtPass.Text))
                {
                    MessageBox.Show("provide ID and Password");
                }




                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=pc101;Initial Catalog=SMS;ID=sa;Password=mike";
                conn.Open();

                string UserName = txtId.Text;
                string Password = txtPass.Text;


                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE Id = '" + txtId.Text + "' and password = '" + txtPass.Text + "'", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                System.Data.SqlClient.SqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"])
                    {
                        ConnectionString = "Data Source=pc101;Initial Catalog=SMS;User ID=sa;Password=mike"
                    };
                    con.Open();

                    if (this.txtId.Text == dr["Id"].ToString() & this.txtPass.Text == dr["password"].ToString())
                    {
                        MessageBox.Show("*** Login Successful ***");

                        this.Hide();
                    }

                    else if (this.txtId.Text == dr["Id"].ToString() & this.txtPass.Text == dr["password"].ToString())
                    {
                        MessageBox.Show("*** Login Successful ***");

                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Invalid Id or Password", "Login");
                        MessageBox.Show("Access Denied!!");

                    }
                }
            }
        }
    }
}

