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
using System.Windows.Shapes;

namespace ManagerPOS
{
    /// <summary>
    /// Interaction logic for EmpList.xaml
    /// </summary>
    public partial class EmpList : Window
    {

        Database db = new Database();
        public EmpList()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                ReloadEmployeeList();
            
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string SIN = txtSIN.Text;
            string phone = txtPhone.Text;
            string street = txtStreet.Text;
            string ciry = txtCity.Text;
            string postal = txtPostal.Text;
            string pswd = txtPassword.Text;

            Employee emp = new Employee();
            emp.FName = fName;
            emp.LName = lName;
            emp.Phone = phone;
            emp.SIN = SIN;
            emp.Street = street;
            emp.City = ciry;
            emp.Password = pswd;
            emp.Postal = postal;

            db.AddEmployee(emp);

            List<Employee> empList = new List<Employee>();
            ReloadEmployeeList();



        }
        private void ReloadEmployeeList()
        {
            List<Employee> list = db.GetAllEmployees();
            lstEmployees.Items.Clear();
            foreach (Employee e in list)
            {
                lstEmployees.Items.Add(e);
            }
        }

    }

}
