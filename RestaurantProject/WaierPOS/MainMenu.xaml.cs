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

namespace WaierPOS
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            //    string empName = Application.Current.FindResource("EmpName").ToString();
            //   lblMessage.Content = String.Format("Hello, {0}", empName);


        }
        public void DisplayEmpName(string name) {
            lblMessage.Content = String.Format("Hello " + name);

        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            
            OrderWindow orderWin = new OrderWindow();
            orderWin.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { PrintingBill printWin = new PrintingBill();
            printWin.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow(this);
            login.ShowDialog();
        }
    }
}
