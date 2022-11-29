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
    /// Логика взаимодействия для EditAdminWindow.xaml
    /// </summary>
    public partial class EditAdminWindow : Window
    {
        public EditAdminWindow(user user)
        {
            InitializeComponent();
            DataContext = user;
            RoleCb.ItemsSource = DBEntities.Getcontext()
                .Role.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            user user = DBEntities.Getcontext().user.
               FirstOrDefault(s => s.UserId == VariableClass.UserId);
            user.Login = LoginTb.Text;
            user.Password = PasswordTb.Text;
            user.IdRole = Int32.Parse(RoleCb.SelectedValue.ToString());
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Сотрудник успешно отредактирован");
            new AdminFolder.MenuAdminWindow();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
