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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputersFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAMFolder
{
    /// <summary>
    /// Логика взаимодействия для RAMEditPage.xaml
    /// </summary>
    public partial class RAMEditPage : Page
    {
        string saveSerial = "";
        private RAM originalRAM;
        public RAMEditPage(RAM ram)
        {
            InitializeComponent();
            originalRAM = DBEntities.GetContext().RAM
                .FirstOrDefault(u => u.IdRAM == ram.IdRAM);
            DataContext = originalRAM;
            this.originalRAM.IdRAM = originalRAM.IdRAM;
            TypeRAMCb.ItemsSource = DBEntities.GetContext()
                .TypeOfRAM.ToList();
            SeriesRAMTB.Text = saveSerial = ram.SerialNumberRAM;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberRAM = DBEntities.GetContext()
                            .RAM.FirstOrDefault(u => u.SerialNumberRAM == SeriesRAMTB.Text);
            if (checkSerialNumberRAM != null && saveSerial != SeriesRAMTB.Text)
            {
                MBClass.ErrorMB("Такой серийный номер уже существует");
                SeriesRAMTB.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(SeriesRAMTB.Text))
            {
                MBClass.ErrorMB("Пожалуйста, введите серийный номер");
                SeriesRAMTB.Focus();
            }

            else
            {
                try
                {
                    originalRAM = DBEntities.GetContext().RAM
                        .FirstOrDefault(u => u.IdRAM == originalRAM.IdRAM);
                    originalRAM.NameRAM = NameRAMTB.Text;
                    originalRAM.IdTypeOfRAM = Int32.Parse(
                        TypeRAMCb.SelectedValue.ToString());
                    originalRAM.SerialNumberRAM = SeriesRAMTB.Text;
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
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
