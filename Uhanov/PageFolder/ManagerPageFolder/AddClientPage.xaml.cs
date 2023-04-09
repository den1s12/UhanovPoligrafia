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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {           
            if (string.IsNullOrWhiteSpace(LastNameTB.Text))
            {
                MBClass.ErrorMB("Введите фамилию");
                LastNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FirstNameTB.Text))
            {
                MBClass.ErrorMB("Введите имя");
                FirstNameTB.Focus();
            }            
            else if (string.IsNullOrWhiteSpace(PhoneNumberTB.Text))
            {
                MBClass.ErrorMB("Введите телефон");
                PhoneNumberTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(EmailTB.Text))
            {
                MBClass.ErrorMB("Введите почту");
                EmailTB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Client.Add(new Client()
                    {
                        LastNameClient = LastNameTB.Text,
                        FirstNameClient = FirstNameTB.Text,
                        MiddleNameClient = MiddleNameTB.Text,
                        NameCompany = NameCompanyTB.Text,
                        PhoneNumberClient = PhoneNumberTB.Text,
                        EmailClient = EmailTB.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Клиент успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListClientPage());
        }
    }
}
