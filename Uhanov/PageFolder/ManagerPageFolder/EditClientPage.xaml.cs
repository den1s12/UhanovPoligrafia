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

namespace Uhanov.PageFolder.ManagerPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        public EditClientPage(Client client)
        {
            InitializeComponent();
            DataContext = client;
        }

        private void EditClientBtn_Click(object sender, RoutedEventArgs e)
        {
            Client client = DBEntities.GetContext().Client.
             FirstOrDefault(s => s.IdClient == VariableClass.ClientId);
            client.LastNameClient = LastNameTB.Text;
            client.FirstNameClient = FirstNameTB.Text;
            client.MiddleNameClient = MiddleNameTB.Text;
            client.NameCompany = NameCompanyTB.Text;
            client.PhoneNumberClient = PhoneNumberTB.Text;
            client.EmailClient = EmailTB.Text;
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Клиент успешно отредактирован");
            NavigationService.Navigate(new ListClientPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListClientPage());
        }
    }
}
