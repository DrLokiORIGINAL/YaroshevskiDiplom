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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM3Folder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM4Folder
{
    /// <summary>
    /// Логика взаимодействия для RAM4AddPage.xaml
    /// </summary>
    public partial class RAM4AddPage : Page
    {
        public RAM4AddPage()
        {
            InitializeComponent();
            RAMCb.ItemsSource = DBEntities.GetContext()
                .RAM.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RAMCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберите оперативную память");
                RAMCb.Focus();
            }

            else
            {
                try
                {
                    DBEntities.GetContext().RAM4.Add(new RAM4()
                    {
                        IdRAM = Int32.Parse(RAMCb.SelectedValue.ToString()),
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Успешно");
                    NavigationService.Navigate(new RAM4ListPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    throw;
                }
            }
        }
    }
}
