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


namespace WaierPOS
{
    /// <summary>
    /// Interaction logic for PrintingBill.xaml
    /// </summary>
    public partial class PrintingBill : Window
    {
        Boolean islist1Modified = false;
        


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
            List<OrderedItem> list = db.GetAllOrders(orderId); 
            List1.Items.Clear();
            foreach (OrderedItem o in list)
            {
                List1.Items.Add(o);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int orderId = System.Convert.ToInt32(txtId.Text);
       
            
            ReloadOrderList(orderId);
            islist1Modified = true;
        }

        ////ADD from list1 to list2
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int orderdetalid = System.Convert.ToInt32(txtId.Text);
            int paymentId = db.AddNewPayment();
            //int item = (int)List1.SelectedItem;
            db.UpdateOrderDetailsByPaymentId(orderdetalid, paymentId);
            List<OrderedItem> list = db.GetAllOrderDetailByPaymentId(orderdetalid, paymentId);
            List2.Items.Clear();
            foreach (OrderedItem o in list)
            {
                List2.Items.Add(o);
            }

        }
        }
    }
    

