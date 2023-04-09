using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
            ClientCB.ItemsSource = DBEntities.GetContext().Client.ToList();
            ManagerCB.ItemsSource = DBEntities.GetContext().Employee.ToList();
            OrderStatusCB.ItemsSource = DBEntities.GetContext().StatusOrder.ToList();
            PaymentStatusCB.ItemsSource = DBEntities.GetContext().StatusPayment.ToList();
            PositionCB.ItemsSource = DBEntities.GetContext().PriceList.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите клиента");
                ClientCB.Focus();
            }
            else if (ManagerCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите менеджера");
                ManagerCB.Focus();
            }
            else if (PositionCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите");
                PositionCB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(CountTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                CountTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TotalPriceTB.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                TotalPriceTB.Focus();
            }
            else if (OrderStatusCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль для пользователя");
                OrderStatusCB.Focus();
            }
            else if (PaymentStatusCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль для пользователя");
                PaymentStatusCB.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Order.Add(new Order()
                    {
                        CountExemplar = CountTB.Text,
                        TotalPrice = Int32.Parse(TotalPriceTB.Text),
                        OrderDate = DateTime.Parse(OrderDateTB.Text),
                        DateOfIssueOrder = DateTime.Parse(IssueDateTB.Text),
                        IdPosition = Int32.Parse(PositionCB.SelectedValue.ToString()),
                        IdClient = Int32.Parse(ClientCB.SelectedValue.ToString()),
                        IdStatusOrder = Int32.Parse(OrderStatusCB.SelectedValue.ToString()),
                        IdStatusPayment = Int32.Parse(PaymentStatusCB.SelectedValue.ToString()),
                        IdEmployee = Int32.Parse(ManagerCB.SelectedValue.ToString())
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Пользователь успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOrderPage());
        }
    }
}
