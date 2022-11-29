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
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow()
        {
            InitializeComponent();
            StatusCb.ItemsSource = DBEntities.Getcontext()
               .Status.ToList();

                JKCb.ItemsSource = DBEntities.Getcontext()
               .JK.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HouseNumberTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер дома");
            }
            else if (NumberTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (TotalAreaTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите общую");
            }
            else if (LivingAreaTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (NumberOfRoomsTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
            }
            else if (CostTb.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите номер");
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
            DBEntities.Getcontext().Flat.Add(new Flat()
            {
                HouseNumber = HouseNumberTb.Text,
                Number = NumberTb.Text,
                TotalArea = TotalAreaTb.Text,
                LivingArea = LivingAreaTb.Text,
                NumberOfRooms = NumberOfRoomsTb.Text,
                Cost = CostTb.Text,
                IdStatus = Int32.Parse(StatusCb.SelectedValue.ToString()),
                IdJK = Int32.Parse(JKCb.SelectedValue.ToString())
            });
            DBEntities.Getcontext().SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}