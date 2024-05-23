using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YaroshevskiDiplom.ClassFolder;
using YaroshevskiDiplom.DataFolder;
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM1Folder;
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM4Folder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAMFolder
{
    /// <summary>
    /// Логика взаимодействия для RAMAddPage.xaml
    /// </summary>
    public partial class RAMAddPage : Page
    {
        RAM ram = new RAM();
        public RAMAddPage()
        {
            InitializeComponent();
            RAMCb.ItemsSource = DBEntities.GetContext()
                .TypeOfRAM.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameRAMTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите название ОЗУ");
                NameRAMTB.Focus();
            }

            else if (string.IsNullOrWhiteSpace(SeriesRAMTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите серийный номер ОЗУ");
                SeriesRAMTB.Focus();
            }
            else
            { 
                try
                {
                    DBEntities.GetContext().RAM.Add(new RAM()
                    {
                        NameRAM = NameRAMTB.Text,
                        IdTypeOfRAM = Int32.Parse(RAMCb.SelectedValue.ToString()),
                        SerialNumberRAM = SeriesRAMTB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Успешно");
                    NavigationService.Navigate(new RAMListPage());
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
