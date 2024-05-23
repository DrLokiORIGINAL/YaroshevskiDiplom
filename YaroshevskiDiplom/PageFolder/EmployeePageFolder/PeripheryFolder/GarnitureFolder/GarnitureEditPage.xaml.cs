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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.PeripheryFolder.ComputerMouseFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.PeripheryFolder.GarnitureFolder
{
    /// <summary>
    /// Логика взаимодействия для GarnitureEditPage.xaml
    /// </summary>
    public partial class GarnitureEditPage : Page
    {
        string saveSerial = "";
        private Garniture originalGarniture;
        public GarnitureEditPage(Garniture garniture)
        {
            InitializeComponent();
            originalGarniture = DBEntities.GetContext().Garniture
                .FirstOrDefault(u => u.IdGarniture == garniture.IdGarniture);
            DataContext = garniture;
            this.originalGarniture.IdGarniture = originalGarniture.IdGarniture;
            SerialTB.Text = saveSerial = garniture.SerialNumberGarniture;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberG = DBEntities.GetContext()
                            .Garniture.FirstOrDefault(u => u.SerialNumberGarniture == SerialTB.Text);
            if (checkSerialNumberG != null && saveSerial != SerialTB.Text)
            {
                MBClass.ErrorMB("Такой серийный номер уже существует");
                SerialTB.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(SerialTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите серийный номер");
                SerialTB.Focus();
            }

            else
            {
                try
                {
                    originalGarniture = DBEntities.GetContext().Garniture
                        .FirstOrDefault(u => u.IdGarniture == originalGarniture.IdGarniture);
                    originalGarniture.NameGarniture = NameTB.Text;
                    originalGarniture.SerialNumberGarniture = SerialTB.Text;
                    originalGarniture.GaranteeGarniture = Convert.ToDateTime(DateDP.SelectedDate);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
                    NavigationService.Navigate(new GarnitureListPage());
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
