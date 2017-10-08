using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

            //this.txtId.MouseDoubleClick += new MouseEventHandler(txtId_MouseDoubleClick);



        }
        private Process process;
        private string getKeyboardText()
        {
            Keyboard k = new Keyboard();
            k.ShowDialog();
            if (k.DialogResult.ToString().Equals("OK"))
                return k.Text1;
            else
                return null;
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
                        ConnectionString = @"Server=tcp:mihoaka.database.windows.net,1433;Initial Catalog=Restaurant;Persist Security Info=False;User ID=sqladmin;Password=Mihoaka0215;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                
                    con.Open();

                    if (this.txtId.Text == dr["Id"].ToString() & this.txtPass.Text == dr["password"].ToString())
                    {
                        MessageBox.Show("*** Login Successful ***");

                        this.Hide();
                    }

                    else if (this.txtId.Text == dr["Id"].ToString() & this.txtPass.Text == dr["password"].ToString())
                    {
                       
                  
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Invalid Id or Password", "Login");
                        MessageBox.Show("Access Denied!!");

                    }
                }
            }
        }

        private void txtId_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.txtId.Text = getKeyboardText();
        }

        private void txtPass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            this.txtPass.Text = getKeyboardText();
        }
        private void showKeypad()
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "c:\\Windows\\system32\\osk.exe";
            process.StartInfo.Arguments = "";
            process.StartInfo.WorkingDirectory = "c:\\";
            process.Start(); // Start Onscreen Keyboard
            process.WaitForInputIdle();
            //Win32.SetWindowPos((int)process.MainWindowHandle,
            //Win32.HWND_BOTTOM,
            //300, 300, 1200, 600,
            //Win32.SWP_SHOWWINDOW | Win32.SWP_NOZORDER);


        }



    }
}

