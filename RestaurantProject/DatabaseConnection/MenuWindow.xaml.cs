﻿using System;
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
            OrderWindow tableWin = new OrderWindow();
            tableWin.Show();
        }
    }
}
