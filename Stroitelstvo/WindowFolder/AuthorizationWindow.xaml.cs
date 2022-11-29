using Stroitelstvo.ClassFolder;
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
using Stroitelstvo.DataFolder;

namespace Stroitelstvo.WindowFolder
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

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            if (string.IsNullOrEmpty(PasswordTb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordTb.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.Getcontext().user.FirstOrDefault
                        (u => u.Login == LoginTb.Text);
                    if (user == null)
                    {
                        MBClass.ErrorMB("Пользователь не найден");
                        LoginTb.Focus();
                        return;
                    }
                    if (user.Password != PasswordTb.Password)
                    {
                        MBClass.ErrorMB("Введен неправильный пароль");
                        PasswordTb.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 3:
                                new ManagerFolder.MenuManagerWindow().ShowDialog();
                                break;
                            case 2:
                                new StaffFolder.MenuStaffWindow().ShowDialog();
                                break;
                            case 1:
                                new AdminFolder.MenuAdminWindow().ShowDialog();
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

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegistratonWindow().ShowDialog();
        }
    }
}
