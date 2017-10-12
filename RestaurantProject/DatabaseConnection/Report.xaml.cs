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
        string strDate;
        public Report()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                strDate = DateTime.Now.ToString("yyyy-MM-dd");
                MessageBox.Show(strDate);
                ReloadAllLists(strDate);
     

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    private void ReloadSalesList(ListView lv,string date,int category)
        {
            lv.Items.Clear();
            List<OrderedItem> list = db.GetTopSales(date, category);
            
            foreach (OrderedItem item in list)
            {
                lv.Items.Add(item);
            }
        }
        private void ReloadAllLists(string date) {
            ReloadSalesList(lstDrink, strDate, 10);
            ReloadSalesList(lstStarter, strDate, 20);
            ReloadSalesList(lstMain, strDate, 30);
            ReloadSalesList(lstDessert, strDate, 40);

        }

        private void dpicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            strDate = dpicker.ToString();
            ReloadAllLists(strDate);
        }
    }
    }

