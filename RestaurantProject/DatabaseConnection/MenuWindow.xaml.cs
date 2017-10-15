using System;
using System.Collections.Generic;
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
using SharedLibrary;
namespace ManagerPOS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {

    
                InitializeComponent();
              

            }
        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmpList empWin = new EmpList();
            empWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Report reportWin = new Report();
            reportWin.Show();
            this.Close();
        }

  

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.ShowDialog();
        }
    }
}
