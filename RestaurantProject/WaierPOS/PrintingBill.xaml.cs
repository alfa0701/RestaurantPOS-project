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
        int orderId;
        int paymentId;
        string empName;
        string strSubtotal, strTotal, strTax;
        Database db;
        public PrintingBill()
        {
            empName = Application.Current.FindResource("EmpName").ToString();
            try
            {
                db = new Database();
                InitializeComponent();
                lblEmp.Content = String.Format("Employee :{0}", empName);

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
            string strOrderId = txtId.Text;

            try
            {
                orderId = int.Parse(strOrderId);
                ReloadOrderList(orderId);
            }
            catch (FormatException ex) {
                MessageBox.Show("OrderId must be integers\n" + ex.Message);
            }


        }

        ////ADD from list1 to list2


        public void ShowTotal()
        {
            tax = subtotal * 0.15;
            total = subtotal + tax;
             strSubtotal = String.Format("{0:C2}", Convert.ToDecimal(subtotal));
             strTax = String.Format("{0:C2}", Convert.ToDecimal(tax));
             strTotal = String.Format("{0:C2}", Convert.ToDecimal(total));

            txtSub.Text = Convert.ToString(strSubtotal);
            txtTax.Text = Convert.ToString(strTax);
            txtTotal.Text = Convert.ToString(strTotal);

        }
        public void ClearTotal() {
            txtSub.Text = "";
            txtTax.Text = "";
            txtTotal.Text = "";
        }

        private void btAll_Click(object sender, RoutedEventArgs e)
        {
            List<OrderDetail> list = db.GetAllOrders(orderId);


            foreach (OrderDetail o in list)
            {
                lstPayment.Items.Add(o);
                subtotal += Convert.ToDouble(o.Price);
            }
            lstOrder.Items.Clear();
            ShowTotal();

        }



        private void lstOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderDetail selected = (OrderDetail)lstOrder.SelectedItem;
            lstPayment.Items.Add(selected);
            lstOrder.Items.Remove(selected);
            subtotal += Convert.ToDouble(selected.Price);
            ShowTotal();
        }

        private void lstPayment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderDetail selected = (OrderDetail)lstPayment.SelectedItem;
            lstOrder.Items.Add(selected);
            lstPayment.Items.Remove(selected);
            subtotal -= Convert.ToDouble(selected.Price);
            ShowTotal();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            paymentId = db.AddNewPayment(orderId);
            for (int i = 0; i < lstPayment.Items.Count; i++)
            {
                OrderDetail od = (OrderDetail)lstPayment.Items[i];
                int odId = od.OrderDetailId;
                db.UpdateOrderDetailsPaymentId(odId, paymentId);
            }


            // Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically.
            List<OrderDetail> list = db.GetAllOrderDetailByPaymentId(orderId, paymentId);
            FlowDocument doc = CreateFlowDocument(paymentId, list);
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "RestranPOS Printing.");
            lstPayment.Items.Clear();
            ClearTotal();
            txtId.Text = "";
            this.Close();

        }

        private FlowDocument CreateFlowDocument(int paymentId, List<OrderDetail> list)
        {
            string line;

            // Create a FlowDocument
            FlowDocument doc = new FlowDocument();

            // Create a Section
            Section sec = new Section();

            // Create first Paragraph

            string strPaymentid = String.Format("Check: #{0}", Convert.ToString(paymentId));
            string date = String.Format("Date:{0}", DateTime.Now.ToString());
            string employee = String.Format("Server:{0}", empName);
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();
            Paragraph p3 = new Paragraph();
            p1.Inlines.Add("Restaurant Project\n address\n\n ");
            p1.Inlines.Add(date +"\n"+strPaymentid+"\n");
            p1.Inlines.Add(employee.PadRight(15) + "\n");
            foreach (OrderDetail item in list)
        {
                string strLine = String.Format("{0} {1} {2}", item.MenuName, item.Qty,item.Price+"\n");
                    /*item.MenuName.PadRight(25, ' ')
                    +(item.Qty.ToString()).PadRight(5,' ')
                    +(item.Price.ToString()).PadRight(10,' ') + "\n";  */
            p2.Inlines.Add(strLine);
        }
            p3.Inlines.Add("==============================");
            p3.Inlines.Add(("Subtotal: ").PadLeft(25,' ')+ strSubtotal+ "\n");
            p3.Inlines.Add(("Tax : ").PadLeft(25,' ') + strTax + "\n");
            p3.Inlines.Add(("Total : ").PadLeft(25,' ') + strTotal + "\n");
            p3.Inlines.Add("==============================");



            // Add Paragraph to Section
            sec.Blocks.Add(p1);
             sec.Blocks.Add(p2);
            sec.Blocks.Add(p3);
<<<<<<< HEAD
=======


>>>>>>> c911fd2bae2944e4b2dfc46b455a2ef5ed836046
            // Add Section to FlowDocument
            doc.Blocks.Add(sec);

        return doc;
    }

}
    }
    
    

    
