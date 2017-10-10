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

namespace WaiterUI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        Database db;
        public MainMenu()
        {
            InitializeComponent();
            db = new Database();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TableChoice table = TableChoice();
            table.Show();
            this.Close();
        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            Order orderWin = new Order();
            orderWin.ShowDialog();
        }
    }
}
