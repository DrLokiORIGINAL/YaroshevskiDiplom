using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;
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

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputersFolder
{
    /// <summary>
    /// Логика взаимодействия для ComputersEditPage.xaml
    /// </summary>
    public partial class ComputersEditPage : Page
    {
        string saveSerial = "";
        Computer computer = new Computer();
        public ComputersEditPage(Computer computer)
        {
            InitializeComponent();
            DataContext = computer;
            this.computer.IdComputer = computer.IdComputer;
            CPUCb.ItemsSource = DBEntities.GetContext()
                .CPU.ToList();
            MotherBoardCb.ItemsSource = DBEntities.GetContext()
                .MotherBoard.ToList();
            RAM1Cb.ItemsSource = DBEntities.GetContext()
                .RAM1.ToList();
            RAM2Cb.ItemsSource = DBEntities.GetContext()
                .RAM2.ToList();
            RAM3Cb.ItemsSource = DBEntities.GetContext()
                .RAM3.ToList();
            RAM4Cb.ItemsSource = DBEntities.GetContext()
                .RAM4.ToList();
            GPUCb.ItemsSource = DBEntities.GetContext()
                .GPU.ToList();
            HDDCb.ItemsSource = DBEntities.GetContext()
                .HDD.ToList();
            CPUСoolingCb.ItemsSource = DBEntities.GetContext()
                .CPUСooling.ToList();
            SSDCb.ItemsSource = DBEntities.GetContext()
                .SSD.ToList();
            ComputerCaseCb.ItemsSource = DBEntities.GetContext()
                .ComputerCase.ToList();
            PowerSupplyCb.ItemsSource = DBEntities.GetContext()
                .PowerSupply.ToList();
            RAM1Cb.SelectedValue = computer.RAM1.IdRAM1;
            RAM2Cb.SelectedValue = computer.RAM2.IdRAM2;
            RAM3Cb.SelectedValue = computer.RAM3.IdRAM3;
            RAM4Cb.SelectedValue = computer.RAM4.IdRAM4;
            SerialNumberComputerTB.Text = saveSerial = computer.SerialNumberComputer;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberComputer = DBEntities.GetContext()
                .Computer.FirstOrDefault(u => u.SerialNumberComputer == SerialNumberComputerTB.Text);
            if (checkSerialNumberComputer != null && saveSerial != SerialNumberComputerTB.Text)
            {
                MBClass.ErrorMB("Такой серийный номер уже существует");
                SerialNumberComputerTB.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(SerialNumberComputerTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите серийный номер");
                SerialNumberComputerTB.Focus();
            }

            else
            {
                try
                {
                    computer = DBEntities.GetContext().Computer
                        .FirstOrDefault(u => u.IdComputer == computer.IdComputer);
                    computer.IdCPU = Int32.Parse(
                        CPUCb.SelectedValue.ToString());
                    computer.IdMotherBoard = Int32.Parse(
                        MotherBoardCb.SelectedValue.ToString());
                    computer.IdRAM1 = Int32.Parse(
                        RAM1Cb.SelectedValue.ToString());
                    computer.IdRAM2 = Int32.Parse(
                        RAM2Cb.SelectedValue.ToString());
                    computer.IdRAM3 = Int32.Parse(
                        RAM3Cb.SelectedValue.ToString());
                    computer.IdRAM4 = Int32.Parse(
                        RAM4Cb.SelectedValue.ToString());
                    computer.IdGPU = Int32.Parse(
                        GPUCb.SelectedValue.ToString());
                    computer.IdHDD = Int32.Parse(
                        HDDCb.SelectedValue.ToString());
                    computer.IdCPUСooling = Int32.Parse(
                        CPUСoolingCb.SelectedValue.ToString());
                    computer.IdSSD = Int32.Parse(
                        SSDCb.SelectedValue.ToString());
                    computer.IdComputerCase = Int32.Parse(
                        ComputerCaseCb.SelectedValue.ToString());
                    computer.IdPowerSupply = Int32.Parse(
                        PowerSupplyCb.SelectedValue.ToString());
                    computer.GuaranteeComputer = Convert.ToDateTime(DateDP.SelectedDate);
                    computer.SerialNumberComputer = SerialNumberComputerTB.Text;
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
                    NavigationService.Navigate(new ComputersListPage());
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

