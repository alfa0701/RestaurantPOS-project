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
        MainMenu parentWindow;
        public MainWindow(MainMenu parent)
        {
            parentWindow = parent;
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
            string pswd = txtPass.Password.ToString();
            string empName = db.GetFullNameOfEmployee(empId);
         
            if (db.CheckLogin(empId,pswd))
            {
              
                this.Close();
                Application.Current.Resources.Add("EmpId",empId);
                Application.Current.Resources.Add("EmpName", empName);
                string Name = Application.Current.FindResource("EmpName").ToString();
                parentWindow.DisplayEmpName(Name);

            }
            else
            {
                MessageBox.Show("Incorrect pasword or Id");
            }
        }

       
    }
}
   
