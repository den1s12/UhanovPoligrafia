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
    /// Логика взаимодействия для ListOrderPage.xaml
    /// </summary>
    public partial class ListOrderPage : Page
    {
        public ListOrderPage()
        {
            InitializeComponent();
            ListOrderDG.ItemsSource = DBEntities.GetContext().Order
                .ToList().OrderBy(u => u.IdOrder);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ListUserDG.ItemsSource = DBEntities.GetContext()
            //   .User.Where(u => u.LoginUser
            //   .StartsWith(SearchTb.Text))
            //   .ToList().OrderBy(u => u.LoginUser);
            //if (ListUserDG.Items.Count <= 0)
            //{
            //    MBClass.ErrorMB("Данные не найдены");
            //}
        }

        private void ListOrderDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (ListOrderDG.SelectedItem == null)
            //{
            //    MBClass.ErrorMB("Вы не выбрали строку");
            //}
            //else
            //{
            //    try
            //    {
            //        User user = ListOrderDG.SelectedItem as User;
            //        VariableClass.UserId = user.IdUser;
            //        NavigationService.Navigate(new EditUserPage(user));
            //    }
            //    catch (Exception ex)
            //    {
            //        MBClass.ErrorMB(ex);
            //    }
            //}
        }

        private void EditM_Click(object sender, RoutedEventArgs e)
        {
            if (ListOrderDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }

            Order order = ListOrderDG.SelectedItem as Order;
            VariableClass.OrderId = order.IdOrder;
            NavigationService.Navigate(new EditOrderPage(order));
        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {
            Order order = ListOrderDG.SelectedItem as Order;

            if (ListOrderDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите заказ" +
                    "для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить" +
                    $"заказ с номером" +
                    $"{order.IdOrder}?"))
                {
                    DBEntities.GetContext().User.Remove(order);
                    DBEntities.GetContext().SaveChanges();

                    MessageBox.Show("Пользователь удален");
                    ListOrderDG.ItemsSource = DBEntities.GetContext()
                        .Order.ToList().OrderBy(u => u.IdOrder);
                }
            }
        }
    }
}
