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
using Uhanov.ClassFolder;
using Uhanov.PageFolder.AdminPageFolder;
using Uhanov.PageFolder.ManagerPageFolder;

namespace Uhanov.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            ManagerFrame.Navigate(new ListOrderPage());
        }

        private void ListOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(new ListOrderPage());
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(new AddOrderPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
