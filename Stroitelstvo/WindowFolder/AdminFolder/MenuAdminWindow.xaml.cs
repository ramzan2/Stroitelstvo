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
    /// Логика взаимодействия для MenuAdminWindow.xaml
    /// </summary>
    public partial class MenuAdminWindow : Window
    {
        public MenuAdminWindow()
        {
            InitializeComponent();
            UserDG.ItemsSource = DBEntities.Getcontext().user.ToList()
               .OrderBy(c => c.UserId);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            user user = UserDG.SelectedItem as user;
            VariableClass.UserId = user.UserId;
            new EditAdminWindow(user).ShowDialog();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddAdminWindow().ShowDialog();
        }
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                UserDG.ItemsSource = DBEntities.Getcontext().user.Where
                (u => u.Login.StartsWith(SearchTb.Text)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            user user = UserDG.SelectedItem as user;
            VariableClass.UserId = user.UserId;
            new EditAdminWindow(user).ShowDialog();
        }
    }
}
