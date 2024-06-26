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
using YaroshevskiDiplom.PageFolder.AdministratorPageFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputersFolder
{
    /// <summary>
    /// Логика взаимодействия для ComputersListPage.xaml
    /// </summary>
    public partial class ComputersListPage : Page
    {
        public ComputersListPage()
        {
            InitializeComponent();
            ListComputerDG.ItemsSource = DBEntities.GetContext().Computer.ToList()
                .OrderBy(c => c.IdComputer);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListComputerDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "компьютер для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new ComputersEditPage(ListComputerDG.SelectedItem as Computer));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Computer computer = ListComputerDG.SelectedItem as Computer;
            if (ListComputerDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите компьютер" +
                    " для удаления");
            }
            else
            {
                try
                {

                
                if (MBClass.QestionMB("Удалить " +
                    $"компьютер с серийным номером " +
                    $"{computer.SerialNumberComputer}?"))
                    {
                        DBEntities.GetContext().Computer
                            .Remove(ListComputerDG.SelectedItem as Computer);
                        DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Компьютер удален");
                        ListComputerDG.ItemsSource = DBEntities.GetContext()
                            .Computer.ToList().OrderBy(u => u.IdComputer);
                }
                }
                catch
                {
                    MBClass.InformationMB("В данный момент компьютер используется");
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListComputerDG.ItemsSource = DBEntities.GetContext()
                .Computer.Where(u => u.SerialNumberComputer.StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.SerialNumberComputer);
        }

        private void Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputersFolder.ComputersAddPage());
        }

        private void ListCPUBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.CPUFolder.CPUListPage());
        }

        private void ListCPUCoolingBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.CPUCoolingFolder.CPUCoolingListPage());
        }

        private void ListGPUBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.GPUFolder.GPUListPage());
        }

        private void ListMotherBoardBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.MotherBoardFolder.MotherBoardListPage());
        }

        private void ListHDDBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.HDDFolder.HDDListPage());
        }

        private void ListComputerCaseBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.ComputerCaseFolder.ComputerCaseListPage());
        }

        private void ListPowerSupplyBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.PowerSupplyFolder.PowerSupplyListPage());
        }

        private void ListRAM1Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM1Folder.RAM1ListPage());
        }

        private void ListRAM2Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM2Folder.RAM2ListPage());
        }

        private void ListRAM3Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM3Folder.RAM3ListPage());
        }

        private void ListRAM4Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM4Folder.RAM4ListPage());
        }

        private void ListRAMBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAMFolder.RAMListPage());
        }

        private void ListSSDBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.EmployeePageFolder.ComputerСomponentsFolder.SSDFolder.SSDListPage());
        }
    }
}
