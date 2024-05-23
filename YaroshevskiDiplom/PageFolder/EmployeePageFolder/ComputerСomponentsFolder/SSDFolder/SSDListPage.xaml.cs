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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YaroshevskiDiplom.ClassFolder;
using YaroshevskiDiplom.DataFolder;
using YaroshevskiDiplom.PageFolder.AdministratorPageFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.SSDFolder
{
    /// <summary>
    /// Логика взаимодействия для SSDListPage.xaml
    /// </summary>
    public partial class SSDListPage : Page
    {
        public SSDListPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().SSD.ToList()
                .OrderBy(c => c.IdSSD);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            SSD ssd = ListAdminDG.SelectedItem as SSD;
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите SSD" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"SSD с названием " +
                    $"{ssd.NameSSD}?"))
                {
                    DBEntities.GetContext().SSD
                        .Remove(ListAdminDG.SelectedItem as SSD);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("SSD удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .SSD.ToList().OrderBy(u => u.NameSSD);
                }
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "SSD для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new SSDEditPage(ListAdminDG.SelectedItem as SSD));
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .SSD.Where(u => u.NameSSD.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.NameSSD);
        }

        private void Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.SSDFolder.SSDAddPage());
        }
    }
}
