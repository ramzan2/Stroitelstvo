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
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        public EditStaffWindow(Flat flat)
        {
            InitializeComponent();
            DataContext = flat;
            StatusCb.ItemsSource = DBEntities.Getcontext()
                .Status.ToList();
            JKCb.ItemsSource = DBEntities.Getcontext()
               .JK.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Flat flat = DBEntities.Getcontext().Flat.
               FirstOrDefault(s => s.IdFlat == VariableClass.IdFlat);
            flat.HouseNumber = HouseNumberTb.Text;
            flat.Number = NumberTb.Text;
            flat.TotalArea = TotalAreaTb.Text;
            flat.LivingArea = LivingAreaTb.Text;
            flat.NumberOfRooms = NumberOfRoomsTb.Text;
            flat.Cost = CostTb.Text;
            flat.IdStatus = Int32.Parse(StatusCb.SelectedValue.ToString());
            flat.IdJK = Int32.Parse(JKCb.SelectedValue.ToString());
            DBEntities.Getcontext().SaveChanges();
            MBClass.InformationMB("Сотрудник успешно отредактирован");
            new StaffFolder.MenuStaffWindow();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
