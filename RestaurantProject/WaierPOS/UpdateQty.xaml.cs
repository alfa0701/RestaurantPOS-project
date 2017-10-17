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
    /// Interaction logic for UpdateQty.xaml
    /// </summary>
    public partial class UpdateQty : Window
    {
        Database db;
        int menuId;
        int qty;
        int orderId;
        string menuName;

        OrderWindow parentOrderWindow;

        public UpdateQty(OrderWindow parent)
        {
            parentOrderWindow = parent;
            try
            {
                db = new Database();
                InitializeComponent();
                orderId = Convert.ToInt32(Application.Current.FindResource("OrderId"));
                menuId = Convert.ToInt32(Application.Current.FindResource("MenuId"));
                qty = Convert.ToInt32(Application.Current.FindResource("Qty"));
                menuName = Application.Current.FindResource("MenuName").ToString();
                lblName.Content = menuName;
                txtCount.Text =qty.ToString(); 


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            qty = Convert.ToInt32(txtCount.Text);
            db.UpdateOrderDetailQty(orderId, menuId, qty);
            MessageBox.Show(String.Format("Order is updated.\n" +
                "{0} * {1}", menuName, qty));
            Application.Current.Resources.Remove("MenuName");
            Application.Current.Resources.Remove("MenuId");
            Application.Current.Resources.Remove("OrderId");
            Application.Current.Resources.Remove("Qty");
            this.Close();
            parentOrderWindow.ReloadOrderList();
        }


        private void btPlus_Click(object sender, RoutedEventArgs e)
        {
            qty += 1;
            txtCount.Text = qty.ToString();
               
        }

        private void btMinus_Click(object sender, RoutedEventArgs e)
        {
            qty -= 1;
            
            txtCount.Text = qty.ToString();
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (qty <= 0)
            {
                btMinus.IsEnabled = false;
            }
            else
            {
                btMinus.IsEnabled = true;
            }
        }
    }
}
