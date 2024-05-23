using System;
using System.Collections;
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
using YaroshevskiDiplom.PageFolder.DirectorPageFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.OfficeStorageFolder
{
    /// <summary>
    /// Логика взаимодействия для OfficeStorageEditPage.xaml
    /// </summary>
    public partial class OfficeStorageEditPage : Page
    {
        private OfficeStorage originalStorage;
        public OfficeStorageEditPage(OfficeStorage officestorage)
        {
            InitializeComponent();
            originalStorage = DBEntities.GetContext().OfficeStorage
                .FirstOrDefault(u => u.IdOfficeStorage == officestorage.IdOfficeStorage);
            DataContext = officestorage;
            this.originalStorage.IdOfficeStorage = originalStorage.IdOfficeStorage;
            ComputerCb.ItemsSource = DBEntities.GetContext()
                .Computer.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
            KeyboardCb.ItemsSource = DBEntities.GetContext()
                .Keyboard.ToList();
            ComputerMouseCb.ItemsSource = DBEntities.GetContext()
                .ComputerMouse.ToList();
            ScannerCb.ItemsSource = DBEntities.GetContext()
                .Scanner.ToList();
            MicrophoneCb.ItemsSource = DBEntities.GetContext()
                .Microphone.ToList();
            WebCameraCb.ItemsSource = DBEntities.GetContext()
                .WebCamera.ToList();
            MonitorCb.ItemsSource = DBEntities.GetContext()
                .Monitor.ToList();
            PrinterCb.ItemsSource = DBEntities.GetContext()
                .Printer.ToList();
            HeadphonesCb.ItemsSource = DBEntities.GetContext()
                .Headphones.ToList();
            GarnitureCb.ItemsSource = DBEntities.GetContext()
                .Garniture.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComputerCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберете компьютер");
                ComputerCb.Focus();
            }

            else if (string.IsNullOrWhiteSpace(StaffCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберете сотрудника");
                StaffCb.Focus();
            }

            else if (string.IsNullOrWhiteSpace(KeyboardCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберрете клавиатуру");
                KeyboardCb.Focus();
            }

            else if (string.IsNullOrWhiteSpace(KeyboardCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберете комп. мышь");
                KeyboardCb.Focus();
            }

            else if (string.IsNullOrWhiteSpace(MonitorCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберете монитор");
                MonitorCb.Focus();
            }

            else
            {
                try
                {
                    originalStorage = DBEntities.GetContext().OfficeStorage
                        .FirstOrDefault(u => u.IdOfficeStorage == originalStorage.IdOfficeStorage);
                    originalStorage.IdComputer = Int32.Parse(
                        ComputerCb.SelectedValue.ToString());
                    originalStorage.IdStaff = Int32.Parse(
                        StaffCb.SelectedValue.ToString());
                    originalStorage.IdKeyboard = Int32.Parse(
                        KeyboardCb.SelectedValue.ToString());
                    originalStorage.IdComputerMouse = Int32.Parse(
                        ComputerMouseCb.SelectedValue.ToString());
                    originalStorage.IdScanner = Int32.Parse(
                        ScannerCb.SelectedValue.ToString());
                    originalStorage.IdMicrophone = Int32.Parse(
                        MicrophoneCb.SelectedValue.ToString());
                    originalStorage.IdWebCamera = Int32.Parse(
                        WebCameraCb.SelectedValue.ToString());
                    originalStorage.IdMonitor = Int32.Parse(
                        MonitorCb.SelectedValue.ToString());
                    originalStorage.IdPrinter = Int32.Parse(
                        PrinterCb.SelectedValue.ToString());
                    originalStorage.IdHeadphones = Int32.Parse(
                        HeadphonesCb.SelectedValue.ToString());
                    originalStorage.IdGarniture = Int32.Parse(
                        GarnitureCb.SelectedValue.ToString());
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
                    NavigationService.Navigate(new OfficeStorageListPage());
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
