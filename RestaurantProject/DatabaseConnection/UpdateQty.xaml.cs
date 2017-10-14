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

namespace DatabaseConnection
{
    /// <summary>
    /// Interaction logic for UpdateQty.xaml
    /// </summary>
    public partial class UpdateQty : Window
    {
        public UpdateQty()
        {
            txtCount.Text = "";
            lblName.Content = "";

            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btPlus_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private void btMinus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
