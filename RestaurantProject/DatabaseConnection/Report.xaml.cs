using System;
using System.Collections.Generic;
using System.Data;
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
using System.Configuration;
using SharedLibrary;


namespace ManagerPOS
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        Database db;
        public Report()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                ReloadSalesList(DateTime.Now);


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
        private void ReloadSalesList(DateTime date)
        {
            lstMain.Items.Clear();
            List<OrderedItem> list = db.GetTopSales(date,30);
            
            foreach (OrderedItem item in list)
            {
                lstMain.Items.Add(item);
            }
        }
    }
    }

