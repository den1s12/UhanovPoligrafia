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

namespace Uhanov.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            AdminFrame.Navigate(new UserListPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new AddUserPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new UserListPage());
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
