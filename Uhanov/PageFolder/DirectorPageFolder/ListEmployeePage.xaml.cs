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
using Uhanov.PageFolder.ManagerPageFolder;

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
            if (ListEmployeeDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    Employee employee = ListEmployeeDG.SelectedItem as Employee;
                    VariableClass.EmployeeId = employee.IdEmployee;
                    NavigationService.Navigate(new EditEmployeePage(employee));
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void EditM_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmployeeDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "сотрудника для редактирования");
            }

            Employee employee = ListEmployeeDG.SelectedItem as Employee;
            VariableClass.EmployeeId = employee.IdEmployee;
            NavigationService.Navigate(new EditEmployeePage(employee));
        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = ListEmployeeDG.SelectedItem as Employee;

            if (ListEmployeeDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника" +
                    "для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить" +
                    $"сотрудника с фамилией" +
                    $"{employee.LastNameEmployee}?"))
                {
                    DBEntities.GetContext().Employee.Remove(employee);
                    DBEntities.GetContext().SaveChanges();

                    MessageBox.Show("Сотрудник удален");
                    ListEmployeeDG.ItemsSource = DBEntities.GetContext()
                        .Employee.ToList().OrderBy(u => u.LastNameEmployee);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
