using SharedLibrary;
using System;
using System.Collections.Generic;
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

namespace WaierPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;

        public MainWindow()
        {

            Database db;
            try
            {
                db = new Database();
                InitializeComponent();


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }

        }
      
       private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            int empId = Convert.ToInt32(txtId.Text);
            string pswd = txtId.Text;
         
            if (db.CheckLogin(empId,pswd))
            {
              
                this.Close();
                Application.Current.Resources.Add("EmpId",empId);

            }
            else
            {
                MessageBox.Show("Incorrect pasword or Id");
            }
        }

       
    }
}
   
