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
    /// Логика взаимодействия для RegistratonWindow.xaml
    /// </summary>
    public partial class RegistratonWindow : Window
    {
        public RegistratonWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите логин");
            }
            else if (PasswordTb.Password == String.Empty)
            {
                MBClass.ErrorMB("Введите пароль");
            }
            else
            {
                AddUser();
                MBClass.InformationMB("Пользователь зарегистрирован");
                this.Close();
            }
        }
        private void AddUser()
        {
            DBEntities.Getcontext().user.Add(new user()
            {
                Login = LoginTb.Text,
                Password = PasswordTb.Password,
                IdRole = 2
            });
            DBEntities.Getcontext().SaveChanges();
        }
    }
}
