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

namespace Stroitelstvo.WindowFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuStaffWindow.xaml
    /// </summary>
    public partial class MenuStaffWindow : Window
    {
        public MenuStaffWindow()
        {
            InitializeComponent();
            StaffDG.ItemsSource = DBEntities.Getcontext().Flat.ToList()
               .OrderBy(c => c.IdFlat);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddStaffWindow().ShowDialog();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            Flat flat = StaffDG.SelectedItem as Flat;
            VariableClass.IdFlat = flat.IdFlat;
            new EditStaffWindow(flat).ShowDialog();
        }
        private void StaffDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Flat flat = StaffDG.SelectedItem as Flat;
            VariableClass.IdFlat = flat.IdFlat;
            new EditStaffWindow(flat).ShowDialog();
        }
    }
}
