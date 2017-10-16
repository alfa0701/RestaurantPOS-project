using SharedLibrary;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ManagerPOS
{
    /// <summary>
    /// Interaction logic for EmpList.xaml
    /// </summary>
    public partial class EmpList : Window
    {
        bool isModified = false;
        int selectedIndex = -1;

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
        private void ReloadEmployeeList()
        {
            List<Employee> list = db.GetAllEmployees();
            lstEmployees.Items.Clear();
            foreach (Employee e in list)
            {
                lstEmployees.Items.Add(e);
            }
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string SIN = txtSIN.Text;
            string phone = txtPhone.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string postal = txtPostal.Text.ToUpper();
            string pswd = txtPassword.Text;
            Employee emp = new Employee();
            try
            {              
                emp.FName = fName;
                emp.LName = lName;
                emp.Phone = phone;
                emp.SIN = SIN;
                emp.Street = street;
                emp.City = city;
                emp.Password = pswd;
                emp.Postal = postal;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Input error: " + ex.Message);

            }

            int newId = db.AddEmployee(emp);
            MessageBox.Show("Added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            clearContent();

            List<Employee> empList = new List<Employee>();
            ReloadEmployeeList();

        }


        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstEmployees.SelectedIndex < 0)
            {
                clearContent();
                btDelete.IsEnabled = false ;
                btUpdate.IsEnabled = false;
                btAdd.IsEnabled = true;
                return;
            }
            else
            {
                btDelete.IsEnabled = true;
                btUpdate.IsEnabled = true;
                btAdd.IsEnabled = false;
                Employee selected = new Employee();
                selected = (Employee)lstEmployees.SelectedItem;
                txtFName.Text = (string)selected.FName;
                txtLName.Text = (string)selected.LName;
                txtSIN.Text = (string)selected.SIN;
                txtPhone.Text = (string)selected.Phone;
                txtStreet.Text = (string)selected.Street;
                txtCity.Text = (string)selected.City;
                txtPostal.Text = (string)selected.Postal.ToUpper();
                txtPassword.Text = (string)selected.Password;
                lblID.Content = String.Format("ID : {0}", selected.EmpId);
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmployees.SelectedIndex < 0)
            {
                MessageBox.Show("Select an employee to delete");

            }
            else
            {
                if (MessageBox.Show("Delete an Employee??", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    Employee selected = new Employee();
                    selected = (Employee)lstEmployees.SelectedItem;
                    db.DeleteEmployeeByID(selected.EmpId);
                    MessageBox.Show("Deleted successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReloadEmployeeList();
                    isModified = false;
                }
            }
        }
        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmployees.SelectedIndex < 0)
            {
                MessageBox.Show("Select an employee to update");
            }
            else
            {
                Employee selected = new Employee();
                try
                {
                    selected = (Employee)lstEmployees.SelectedItem;
                    selected.FName = txtFName.Text;
                    selected.LName = txtLName.Text;
                    selected.SIN = txtSIN.Text;
                    selected.Phone = txtPhone.Text;
                    selected.Street = txtStreet.Text;
                    selected.City = txtCity.Text;
                    selected.Postal = txtPostal.Text.ToUpper();
                    selected.Password = txtPassword.Text;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Input error: " + ex.Message);
                }
                db.UpdateEmployee(selected);
                MessageBox.Show("Updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                ReloadEmployeeList();
                isModified = false;
            }
        }
        public void clearContent()
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtSIN.Text = "";
            txtPhone.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtPostal.Text = "";
            txtPassword.Text = "";
            lblID.Content = "ID : ";
        }

        private void btMain_Click(object sender, RoutedEventArgs e)
        {
            if (isModified)
            {
                if (MessageBox.Show("you have unsaved data. do you exit?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {

                MainMenu menuWin = new MainMenu();
                menuWin.Show();
                this.Close();
            }

        }

        private void txtFName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtPostal_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtSIN_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }

        private void txtFName_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}




