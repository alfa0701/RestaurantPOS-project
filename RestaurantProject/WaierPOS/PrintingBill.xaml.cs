using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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


namespace WaierPOS
{
    /// <summary>
    /// Interaction logic for PrintingBill.xaml
    /// </summary>
    public partial class PrintingBill : Window
    {

        double subtotal = 0;
        double tax;
        double total;


        Database db;
        public PrintingBill()
        {
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
        private void ReloadOrderList(int orderId)
        {
            List<OrderDetail> list = db.GetAllOrders(orderId);
           

            lstOrder.Items.Clear();
            foreach (OrderDetail o in list)
            {
                lstOrder.Items.Add(o);
            }
        }


        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            int orderId = System.Convert.ToInt32(txtId.Text);

            ReloadOrderList(orderId);

        }

        ////ADD from list1 to list2
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            OrderDetail selected =(OrderDetail) lstOrder.SelectedItem;
            lstOrder.Items.Remove(selected);
            lstPayment.Items.Add(selected);
            subtotal += Convert.ToDouble(selected.Price);
           
            ShowTotal();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderDetail selected = (OrderDetail)lstPayment.SelectedItem;
            lstPayment.Items.Remove(selected);
            lstOrder.Items.Add(selected);
            subtotal -= Convert.ToDouble(selected.Price);
            
           
           
            ShowTotal();
        }
        public void ShowTotal()
        {
            tax = subtotal * 0.15;
           total = subtotal + tax;
            string strSubtotal = string.Format("{0:0.00}", subtotal);
            string strTax = string.Format("{0:0.00}", tax);
            string strTotal = string.Format("{0:0.00}", total);

            txtSub.Text = Convert.ToString(strSubtotal);
            txtTax.Text = Convert.ToString(tax);
            txtTotal.Text = Convert.ToString(total);

        }
   


    }
    }
    
    

    
