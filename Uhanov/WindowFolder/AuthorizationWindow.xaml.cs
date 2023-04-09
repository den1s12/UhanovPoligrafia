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
using Uhanov.DataFolder;

namespace Uhanov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }

            if (string.IsNullOrWhiteSpace(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPsb.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User.FirstOrDefault(u => u.LoginUser == LoginTb.Text);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Введен не верный логин");
                        LoginTb.Focus();
                        return;
                    }

                    if (user.PasswordUser != PasswordPsb.Password)
                    {
                        MBClass.ErrorMB("Введен не верный пароль");
                        PasswordPsb.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new AdminFolder.AdminWindow().ShowDialog();
                                break;

                            case 2:
                                new ManagerFolder.ManagerWindow().ShowDialog();
                                break;

                            case 3:
                                new DirectorFolder.DirectorWindow().ShowDialog();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginTb.Focus();
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordPsb.Focus();

        }

        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTb.Text) && LoginTb.Text.Length > 0)
                textLogin.Visibility = Visibility.Collapsed;
            else
                textLogin.Visibility = Visibility.Visible;
        }

        private void PasswordPsb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordPsb.Password) && PasswordPsb.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }
    }
}
