using System;
using System.Collections.Generic;
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
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;";

            Int32 verify;
            string query1 = "Select count(*) from Login where Username='" + Username.Text + "' and Password='" + Password.Text + "' ";
            MySqlCommand cmd1 = new MySqlCommand(query1, con);
            con.Open();
            verify = Convert.ToInt32(cmd1.ExecuteScalar());
            con.Close();

            if (verify > 0)
            {
                new FormMainMenu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect")
            }



        }
}
