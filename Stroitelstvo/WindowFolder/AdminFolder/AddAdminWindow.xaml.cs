using Stroitelstvo.ClassFolder;
using Stroitelstvo.DataFolder;
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

namespace Stroitelstvo.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAdminWindow.xaml
    /// </summary>
    public partial class AddAdminWindow : Window
    {
        public AddAdminWindow()
        {
            InitializeComponent();
            RoleCb.ItemsSource = DBEntities.Getcontext()
               .Role.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите логин");
            }
            else if (PasswordTb.Text == String.Empty)
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
                Password = PasswordTb.Text,
                IdRole = Int32.Parse(RoleCb.SelectedValue.ToString())
            });
            DBEntities.Getcontext().SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
