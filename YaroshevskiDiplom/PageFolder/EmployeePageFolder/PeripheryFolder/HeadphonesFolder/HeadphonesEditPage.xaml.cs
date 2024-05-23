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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.PeripheryFolder.GarnitureFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.PeripheryFolder.HeadphonesFolder
{
    /// <summary>
    /// Логика взаимодействия для HeadphonesEditPage.xaml
    /// </summary>
    public partial class HeadphonesEditPage : Page
    {
        string saveSerial = "";
        private Headphones originalHeadphones;
        public HeadphonesEditPage(Headphones headphones)
        {
            InitializeComponent();
            originalHeadphones = DBEntities.GetContext().Headphones
                .FirstOrDefault(u => u.IdHeadphones == headphones.IdHeadphones);
            DataContext = headphones;
            this.originalHeadphones.IdHeadphones = originalHeadphones.IdHeadphones;
            SerialTB.Text = saveSerial = headphones.SerialNumberHeadphones;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberHP = DBEntities.GetContext()
                            .Headphones.FirstOrDefault(u => u.SerialNumberHeadphones == SerialTB.Text);
            if (checkSerialNumberHP != null && saveSerial != SerialTB.Text)
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
                    originalHeadphones = DBEntities.GetContext().Headphones
                        .FirstOrDefault(u => u.IdHeadphones == originalHeadphones.IdHeadphones);
                    originalHeadphones.NameHeadphones = NameTB.Text;
                    originalHeadphones.SerialNumberHeadphones = SerialTB.Text;
                    originalHeadphones.GuaranteeHeadphones = Convert.ToDateTime(DateDP.SelectedDate);
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
