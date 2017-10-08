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

namespace ManagerPOS
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        int table;
        int guest;
        int orderId;
        
        Database db;
        public OrderWindow()
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
        private void ReloadOrderList()
        {
            List<OrderedItem> list = db.GetAllOrderDetails(orderId);
            lstOrderItem.Items.Clear();
            foreach (OrderedItem o in list)
            {
                lstOrderItem.Items.Add(o);
            }
        }
        private void AddToList(int menuId)
        {
            OrderDetail od = new OrderDetail { OrderId = orderId, MenuId = menuId, Qty = 1 };
            db.AddNewOrderDetail(od);
            ReloadOrderList();
        }

    

        private void cmbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            table = Convert.ToInt32(((ComboBoxItem)cmbTable.SelectedItem).Content);
        }
        private void cmbGuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            guest = Convert.ToInt32(((ComboBoxItem)cmbGuest.SelectedItem).Content);
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (table < 0 || guest < 0)
            {
                MessageBox.Show("select Table and guest count");
                return;
            }
            else
            {
                Order o = new Order { TableNo = table, GuestCount = guest, OrderDate = DateTime.Today };
                orderId = db.AddOrder(o);
                tbctrlMenu.Visibility = Visibility.Visible;
                ReloadOrderList();
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
    }
}
