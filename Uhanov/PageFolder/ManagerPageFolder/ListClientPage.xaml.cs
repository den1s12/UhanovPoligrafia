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
using Uhanov.ClassFolder;
using Uhanov.DataFolder;
using Uhanov.PageFolder.AdminPageFolder;

namespace Uhanov.PageFolder.ManagerPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListClientPage.xaml
    /// </summary>
    public partial class ListClientPage : Page
    {
        public ListClientPage()
        {
            InitializeComponent();
            ListClientDG.ItemsSource = DBEntities.GetContext().Client
               .ToList().OrderBy(u => u.IdClient);
        }

        private void ListClientDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListClientDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    Client client = ListClientDG.SelectedItem as Client;
                    VariableClass.ClientId = client.IdClient;
                    NavigationService.Navigate(new EditClientPage(client));
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void EditM_Click(object sender, RoutedEventArgs e)
        {
            if (ListClientDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "клиента для редактирования");
            }

            Client client = ListClientDG.SelectedItem as Client;
            VariableClass.ClientId = client.IdClient;
            NavigationService.Navigate(new EditClientPage(client));
        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {
            Client client = ListClientDG.SelectedItem as Client;

            if (ListClientDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите клиента" +
                    "для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить" +
                    $"клиента с фамилией" +
                    $"{client.LastNameClient}?"))
                {
                    DBEntities.GetContext().Client.Remove(client);
                    DBEntities.GetContext().SaveChanges();

                    MessageBox.Show("Клиент удален");
                    ListClientDG.ItemsSource = DBEntities.GetContext()
                        .Client.ToList().OrderBy(u => u.LastNameClient);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
