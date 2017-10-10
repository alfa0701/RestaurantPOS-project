
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace SalesReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select m.MenuName, count(od.Qty)as Qty from orderdetail as od " +
                    "inner join menu as m on od.MenuId = m.MenuId inner join[Order] as o on o.orderId = od.OrderId " +
                    "where CAST(o.OrderDate AS DATE) = '2017-10-08' group by m.MenuName order by Qty desc";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("SalesReport");
                sda.Fill(dt);
                grdReport.ItemsSource = dt.DefaultView;
            }
        }
    }
}
