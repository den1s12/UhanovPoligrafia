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
using Uhanov.PageFolder.ManagerPageFolder;

namespace Uhanov.PageFolder.DirectorPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public AddEmployeePage()
        {
            InitializeComponent();
            PostCB.ItemsSource = DBEntities.GetContext()
              .Post.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListEmployeePage());
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
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
                    DBEntities.GetContext().Employee.Add(new Employee()
                    {
                        LastNameEmployee = LastNameTB.Text,
                        FirstNameEmployee = FirstNameTB.Text,
                        MiddleNameEmployee = MiddleNameTB.Text,
                        PhoneNumberEmployee = PhoneNumberTB.Text,
                        EmailEmployee = EmailTB.Text,
                        IdPost = Int32.Parse(PostCB.Text)
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Сотрудник успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
