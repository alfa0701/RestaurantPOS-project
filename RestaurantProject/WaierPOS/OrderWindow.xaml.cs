using System;
using System.Collections.Generic;
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
using SharedLibrary;

using System.Data.SqlClient;

namespace WaierPOS
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        int table;
        int guest;
        int orderId;
        bool isModified = false;
        Order o;
        string empId = Application.Current.FindResource("EmpId").ToString();


        Database db;
        public OrderWindow()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                lblEmp.Content = string.Format("EmpID:{0}", empId);


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
        private void ReloadOrderList()
        {
            List<OrderDetail> list = db.GetAllOrderDetails(orderId);
            lstOrderItem.Items.Clear();
            foreach (OrderDetail o in list)
            {
                lstOrderItem.Items.Add(o);
            }
        }
        private void AddToList(int menuId)
        {
            bool isExist = false;
            foreach (OrderDetail item in lstOrderItem.Items)
            {
                if (item.MenuId == menuId)
                {
                    isExist = true;
                }
            }
            if (isExist)
            {
                db.UpdateOrderDetailQtyBy1(orderId, menuId);
            }
            else
            {
                OrderDetail od = new OrderDetail { OrderId = orderId, MenuId = menuId, Qty = 1 };
                db.AddNewOrderDetail(od);

            }
            ReloadOrderList();
            isModified = true;
        }



        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (cmbGuest.SelectedIndex < 0 || cmbTable.SelectedIndex < 0)
            {
                MessageBox.Show("select Table and guest count");
                return;
            }
            else
            {
                table = Convert.ToInt32(((ComboBoxItem)cmbTable.SelectedItem).Content);
                guest = Convert.ToInt32(((ComboBoxItem)cmbGuest.SelectedItem).Content);
                tbctrlMenu.Visibility = Visibility.Visible;
                DateTime date = DateTime.Now;
                o = new Order { TableNo = table, GuestCount = guest, OrderDate = date };
                orderId = db.AddOrder(o);
                o._orderId = orderId;
                tbctrlMenu.Visibility = Visibility.Visible;
                ReloadOrderList();
                isModified = true;
            }
        }


        private void btBeer_Click(object sender, RoutedEventArgs e)
        {
            AddToList(4);
        }

        private void btOrange_Click(object sender, RoutedEventArgs e)
        {
            AddToList(1);
        }

        private void btCoke_Click(object sender, RoutedEventArgs e)
        {
            AddToList(2);
        }

        private void btPerrier_Click(object sender, RoutedEventArgs e)
        {
            AddToList(3);
        }

        private void btRed_Click(object sender, RoutedEventArgs e)
        {
            AddToList(5);
        }

        private void btWhite_Click(object sender, RoutedEventArgs e)
        {
            AddToList(6);
        }

        private void btSteak_Click(object sender, RoutedEventArgs e)
        {
            AddToList(15);
        }

        private void btChicken_Click(object sender, RoutedEventArgs e)
        {
            AddToList(16);
        }

        private void btHum_Click(object sender, RoutedEventArgs e)
        {
            AddToList(17);
        }

        private void btSpagheti_Click(object sender, RoutedEventArgs e)
        {
            AddToList(18);
        }

        private void btPizza_Click(object sender, RoutedEventArgs e)
        {
            AddToList(19);
        }


        private void btIce_Click(object sender, RoutedEventArgs e)
        {
            AddToList(20);
        }

        private void btChoco_Click(object sender, RoutedEventArgs e)
        {
            AddToList(21);
        }

        private void btCheese_Click(object sender, RoutedEventArgs e)
        {
            AddToList(22);
        }
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            // Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically.
            List<OrderDetail> list = db.GetAllOrderDetails(orderId);
            FlowDocument doc = CreateFlowDocument(o, list);
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            lstOrderItem.Items.Clear();
            cmbGuest.SelectedIndex = -1;
            cmbTable.SelectedIndex = -1;
            orderId = 0;
            MainMenu menuWin = new MainMenu();
            menuWin.Show();
            this.Close();

        }
        private FlowDocument CreateFlowDocument(Order o, List<OrderDetail> list)
        {
            string line;

            // Create a FlowDocument
            FlowDocument doc = new FlowDocument();

            // Create a Section
            Section sec = new Section();

            // Create first Paragraph
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();
            string id = Convert.ToString(o._orderId);
            string table = Convert.ToString(o.TableNo);
            p1.Inlines.Add("OrderID:" + id + "\nTableNo:" + table);
            foreach (OrderDetail item in list)
            {
                line = item.Qty + " " + item.MenuName + "\n";
                p2.Inlines.Add(line);
            }


            // Add Paragraph to Section
            sec.Blocks.Add(p1);
            sec.Blocks.Add(p2);


            // Add Section to FlowDocument
            doc.Blocks.Add(sec);

            return doc;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cancel this order??", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                MessageBox.Show("Order is cancelled.");
                db.DeleteAllOrderDetailByOrderId(orderId);
                db.DeleteOrderByOrderId(orderId);
                lstOrderItem.Items.Clear();
                cmbGuest.SelectedIndex = -1;
                cmbTable.SelectedIndex = -1;


            }
        }

        private void btMain_Click(object sender, RoutedEventArgs e)
        {
            if (isModified)
            {
                if (MessageBox.Show("Cancel this order??", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Order is cancelled.");
                    db.DeleteAllOrderDetailByOrderId(orderId);
                    db.DeleteOrderByOrderId(orderId);
                    MainMenu menuWin = new MainMenu();
                    menuWin.ShowDialog();
                    this.Close();
                }
            }
            else
            {
              
                this.Close();
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstOrderItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}