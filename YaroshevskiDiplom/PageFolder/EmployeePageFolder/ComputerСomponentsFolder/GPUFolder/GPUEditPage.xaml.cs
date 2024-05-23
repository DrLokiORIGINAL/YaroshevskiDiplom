﻿using System;
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

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.GPUFolder
{
    /// <summary>
    /// Логика взаимодействия для GPUEditPage.xaml
    /// </summary>
    public partial class GPUEditPage : Page
    {
        string saveSerial = "";
        private GPU originalGPU;
        public GPUEditPage(GPU gpu)
        {
            InitializeComponent();
            originalGPU = DBEntities.GetContext().GPU
                .FirstOrDefault(u => u.IdGPU == gpu.IdGPU);
            DataContext = gpu;
            this.originalGPU.IdGPU = originalGPU.IdGPU;
            SerialTB.Text = saveSerial = gpu.SerialNumberGPU;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberGPU = DBEntities.GetContext()
                            .GPU.FirstOrDefault(u => u.SerialNumberGPU == SerialTB.Text);
            if (checkSerialNumberGPU != null && saveSerial != SerialTB.Text)
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
                    originalGPU = DBEntities.GetContext().GPU
                        .FirstOrDefault(u => u.IdGPU == originalGPU.IdGPU);
                    originalGPU.NameGPU = NameTB.Text;
                    originalGPU.SerialNumberGPU = SerialTB.Text;
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
                    NavigationService.Navigate(new GPUListPage());
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
