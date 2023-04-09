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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uhanov.DataFolder;

namespace Uhanov.PageFolder.DirectorPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListEmployeePage.xaml
    /// </summary>
    public partial class ListEmployeePage : Page
    {
        public ListEmployeePage()
        {
            InitializeComponent();
            ListEmployeeDG.ItemsSource = DBEntities.GetContext().Employee
               .ToList().OrderBy(u => u.IdEmployee);
        }

        private void ListEmployeeDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void EditM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
