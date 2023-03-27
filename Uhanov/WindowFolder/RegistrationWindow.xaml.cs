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
using System.Windows.Shapes;
using Uhanov.ClassFolder;

namespace Uhanov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && txtLogin.Text.Length > 0)
                txtLogin.Visibility = Visibility.Collapsed;
            else
                txtLogin.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textRepeatPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBoxRepeat.Focus();
        }

        private void passwordBoxRepeat_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().ShowDialog();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MBClass.ErrorMB("Введите логин");
                txtLogin.Focus();
            }
            //else if (DBEntities.GetContext()
            //    .User.FirstOrDefault(u =>
            //    u.Login == txtLogin.Text) != null)
            //{
            //    MBClass.ErrorMB("Такой логин уже существует");
            //    txtLogin.Focus();
            //}
            else if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                passwordBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(passwordBoxRepeat.Password))
            {
                MBClass.ErrorMB("Введите повторно пароль");
                passwordBoxRepeat.Focus();
            }
            else
            {
                //try
                //{
                //    DBEntities.GetContext().User.Add(new User()
                //    {
                //        Login = LoginTb.Text,
                //        Password = PasswordPsb.Password,
                //        IdRole = 2
                //    });
                //    DBEntities.GetContext().SaveChanges();

                //    MBClass.InfoMB("Вы успешно зарегистрировались");
                //}
                //catch (Exception ex)
                //{
                //    MBClass.ErrorMB(ex);
                //}
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
