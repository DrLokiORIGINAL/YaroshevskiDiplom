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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.HDDFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.CPUCoolingFolder
{
    /// <summary>
    /// Логика взаимодействия для CPUCoolingAddPage.xaml
    /// </summary>
    public partial class CPUCoolingAddPage : Page
    {
        public CPUCoolingAddPage()
        {
            InitializeComponent();
            TypeCb.ItemsSource = DBEntities.GetContext()
                .TypeOfCPUСooling.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberCPUC = DBEntities.GetContext()
                .CPUСooling.FirstOrDefault(u => u.SerialNumberCPUCooling == SerialTB.Text);

            if (checkSerialNumberCPUC != null)
            {
                MBClass.ErrorMB("Такой серийный номер уже существует");
                SerialTB.Focus();
            }

            else if (string.IsNullOrWhiteSpace(SerialTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите серийный номер");
                SerialTB.Focus();
            }

            else if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите название");
                NameTB.Focus();
            }

            else if (string.IsNullOrWhiteSpace(TypeCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберете объем жесткого диска");
                TypeCb.Focus();
            }

            else
            {
                try
                {
                    DBEntities.GetContext().CPUСooling.Add(new CPUСooling()
                    {
                        NameCPUСooling = NameTB.Text,
                        IdTypeOfCPUСooling = Int32.Parse(TypeCb.SelectedValue.ToString()),
                        SerialNumberCPUCooling = SerialTB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Успешно");
                    NavigationService.Navigate(new CPUCoolingListPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    throw;
                }
            }
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.CPUCoolingFolder.CPUCoolingListPage());
        }
    }
}
