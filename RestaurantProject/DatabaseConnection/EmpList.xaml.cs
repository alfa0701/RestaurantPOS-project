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
            emp.FName = fName;
            emp.LName = lName;
            emp.Phone = phone;
            emp.SIN = SIN;
            emp.Street = street;
            emp.City = city;
            emp.Password = pswd;
            emp.Postal = postal;
            int newId = db.AddEmployee(emp);




            List<Employee> empList = new List<Employee>();
            ReloadEmployeeList();



        }


        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstEmployees.SelectedIndex < 0) {
                clearContent();
                return;
            }
            else { Employee selected = new Employee();
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
            Employee selected = new Employee();
            selected = (Employee)lstEmployees.SelectedItem;
            db.DeleteEmployeeByID(selected.EmpId);
            ReloadEmployeeList();
            isModified = false;
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            Employee selected = new Employee();
            selected = (Employee)lstEmployees.SelectedItem;
            selected.FName = txtFName.Text;
            selected.LName = txtLName.Text;
            selected.SIN = txtSIN.Text;
            selected.Phone = txtPhone.Text;
            selected.Street = txtStreet.Text;
            selected.City = txtCity.Text;
            selected.Postal = txtPostal.Text.ToUpper();
            selected.Password = txtPassword.Text;
            db.UpdateEmployee(selected);
            ReloadEmployeeList();
            isModified = false;
        }
        public void clearContent() {
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

                    MainMenu menuWin = new MainMenu();
                    menuWin.Show();
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
        /////////////getter and setter>>>>>>>>>>>>>>>>>>>
        

        private string fName;
        private string lName;
        private string phone;
        private string street;
        private string city;
        private string postal;
        private string SIN;

        public int Id { get; set; }
        public string FirstName
        {
            get { return fName; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("FirstName must be between 2 and 50 characters long");
                }
                fName = value;
            }
        }
        public string LastName
        {
            get { return lName; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("LastName must be between 2 and 50 characters long");
                }
                lName = value;
            }
        }
        public string PoneNumber
        {
            get { return phone; }
            set
            {
                if ((Regex.Match(phone, @"^(\+[0-9])$").Success)|| phone.Length ==10)
                {
                    throw new ArgumentOutOfRangeException("Phone number must be 10 digit");
                }

                phone = value;
            }
        }
        public string Phone
        {
            get { return postal; }
            set
            {
                if (Regex.Match(postal, @"^\d{5}$|^\d{5}-\d{4}$").Success)
                {
                    throw new ArgumentOutOfRangeException("Postal Code must be 10 digit");
                }

                postal = value;
            }
        }
        public string SinNumber
        {
            get { return SIN; }
            set
            {
                if ((Regex.Match(SIN, @"^(\+[0-9])$").Success) || SIN.Length == 9)
                {
                    throw new ArgumentOutOfRangeException("Sin number must be 9 digit");
                }

                SIN= value;
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Street must be between 2 and 50 characters long");
                }
                city = value;
            }
        }
        public string Street
        {
            get { return street; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Street must be between 2 and 50 characters long");
                }
                street = value;
            }
        }


    }

}


    