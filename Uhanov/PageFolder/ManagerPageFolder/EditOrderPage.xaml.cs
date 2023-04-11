using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
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
using System.Xml.Linq;
using Uhanov.ClassFolder;
using Uhanov.DataFolder;

namespace Uhanov.PageFolder.ManagerPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        public EditOrderPage(Order order)
        {
            InitializeComponent();
            DataContext = order;
            ClientCB.ItemsSource = DBEntities.GetContext().Client.ToList();
            ManagerCB.ItemsSource = DBEntities.GetContext().Employee.ToList();
            OrderStatusCB.ItemsSource = DBEntities.GetContext().StatusOrder.ToList();
            PaymentStatusCB.ItemsSource = DBEntities.GetContext().StatusPayment.ToList();
            PositionCB.ItemsSource = DBEntities.GetContext().PriceList.ToList();
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order= DBEntities.GetContext().Order.
              FirstOrDefault(s => s.IdOrder == VariableClass.OrderId);
            order.CountExemplar = CountTB.Text;
            order.TotalPrice = Int32.Parse(TotalPriceTB.Text);
            order.OrderDate = DateTime.Parse(OrderDateTB.Text);
            order.DateOfIssueOrder = DateTime.Parse(IssueDateTB.Text);
            order.IdPosition = Int32.Parse(PositionCB.SelectedValue.ToString());
            order.IdClient = Int32.Parse(ClientCB.SelectedValue.ToString());
            order.IdStatusOrder = Int32.Parse(OrderStatusCB.SelectedValue.ToString());
            order.IdStatusPayment = Int32.Parse(PaymentStatusCB.SelectedValue.ToString());
            order.IdEmployee = Int32.Parse(ManagerCB.SelectedValue.ToString());
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Пользователь успешно отредактирован");
            NavigationService.Navigate(new ListOrderPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOrderPage());
        }
    }
}
