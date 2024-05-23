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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM1Folder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM3Folder
{
    /// <summary>
    /// Логика взаимодействия для RAM3EditPage.xaml
    /// </summary>
    public partial class RAM3EditPage : Page
    {
        private RAM3 originalRAM3;
        public RAM3EditPage(RAM3 ram3)
        {
            InitializeComponent();
            originalRAM3 = DBEntities.GetContext().RAM3
                .FirstOrDefault(u => u.IdRAM3 == ram3.IdRAM3);
            DataContext = originalRAM3;
            this.originalRAM3.IdRAM3 = originalRAM3.IdRAM3;
            RAMCb.ItemsSource = DBEntities.GetContext()
                .RAM.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                originalRAM3 = DBEntities.GetContext().RAM3
                        .FirstOrDefault(u => u.IdRAM3 == originalRAM3.IdRAM3);
                originalRAM3.IdRAM = Int32.Parse(
                    RAMCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new RAM3ListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
