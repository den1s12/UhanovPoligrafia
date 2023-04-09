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
using Uhanov.ClassFolder;
using Uhanov.PageFolder.AdminPageFolder;
using Uhanov.PageFolder.DirectorPageFolder;
using Uhanov.PageFolder.ManagerPageFolder;

namespace Uhanov.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        public DirectorWindow()
        {
            InitializeComponent();
            DirectorFrame.Navigate(new ListEmployeePage());
        }

        private void ListEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectorFrame.Navigate(new ListEmployeePage());
        }

        private void ListOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectorFrame.Navigate(new ListOrderPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectorFrame.Navigate(new AddEmployeePage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
