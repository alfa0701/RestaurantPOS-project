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
        public Report()
        {
            InitializeComponent();
            Database db = new Database();
        }
        private void FillDataGrid()
        {
        string CONN_STRING = @"Server=tcp:mihoaka.database.windows.net,1433;Initial Catalog=Restaurant;Persist Security Info=False;User ID=sqladmin;Password=Mihoaka0215;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection conn;

       
            conn = new SqlConnection();
            conn.ConnectionString = CONN_STRING;
            conn.Open();
        
            
                string query = "select m.MenuName, count(od.Qty)as Qty from orderdetail as od inner join menu as m " +
                    "on od.MenuId = m.MenuId inner join [Order] as o on o.orderId= od.OrderId " +
                    "where CAST(o.OrderDate AS DATE) = '2017-10-08' group by m.MenuName order by Qty desc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Sales");
                sda.Fill(dt);
                dgridReport.ItemsSource = dt.DefaultView;
            }
        }
    }

