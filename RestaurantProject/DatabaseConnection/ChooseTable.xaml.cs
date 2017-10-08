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

namespace ManagerPOS

{
    /// <summary>
    /// Interaction logic for ChooseTable.xaml
    /// </summary>
    public partial class ChooseTable : Window
    {

        Database db;
        public ChooseTable()
        {
            InitializeComponent();
           db = new Database();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
         
            OrderWindow orderWin = new OrderWindow();
            orderWin.ShowDialog();
            

        }
    }
}
