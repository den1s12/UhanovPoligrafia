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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        public EditEmployeePage()
        {
            InitializeComponent();
        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = DBEntities.GetContext().Employee.
            FirstOrDefault(s => s.IdEmployee == VariableClass.EmployeeId);
            employee.LastNameEmployee = LastNameTB.Text;
            employee.FirstNameEmployee = FirstNameTB.Text;
            employee.MiddleNameEmployee = MiddleNameTB.Text;
            employee.PhoneNumberEmployee = PhoneNumberTB.Text;
            employee.EmailEmployee = EmailTB.Text;
            employee.IdPost = Int32.Parse(PostCB.SelectedValue.ToString());
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Клиент успешно отредактирован");
            NavigationService.Navigate(new ListEmployeePage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListEmployeePage());
        }
    }
}
