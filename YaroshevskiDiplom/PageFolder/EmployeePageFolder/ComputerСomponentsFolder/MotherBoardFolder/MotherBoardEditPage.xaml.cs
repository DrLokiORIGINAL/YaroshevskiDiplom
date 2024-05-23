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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.PowerSupplyFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.MotherBoardFolder
{
    /// <summary>
    /// Логика взаимодействия для MotherBoardEditPage.xaml
    /// </summary>
    public partial class MotherBoardEditPage : Page
    {
        string saveSerial = "";
        private MotherBoard originalMotherBoard;
        public MotherBoardEditPage(MotherBoard motherboard)
        {
            InitializeComponent();
            originalMotherBoard = DBEntities.GetContext().MotherBoard
                .FirstOrDefault(u => u.IdMotherBoard == motherboard.IdMotherBoard);
            DataContext = motherboard;
            this.originalMotherBoard.IdMotherBoard = originalMotherBoard.IdMotherBoard;
            SerialTB.Text = saveSerial = motherboard.SerialNumberMotherBoard;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkSerialNumberMB = DBEntities.GetContext()
                            .MotherBoard.FirstOrDefault(u => u.SerialNumberMotherBoard == SerialTB.Text);
            if (checkSerialNumberMB != null && saveSerial != SerialTB.Text)
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
                    originalMotherBoard = DBEntities.GetContext().MotherBoard
                        .FirstOrDefault(u => u.IdMotherBoard == originalMotherBoard.IdMotherBoard);
                    originalMotherBoard.NameMotherBoard = NameTB.Text;
                    originalMotherBoard.SocketMotherBoard = SocketTB.Text;
                    originalMotherBoard.SerialNumberMotherBoard = SerialTB.Text;
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
                    NavigationService.Navigate(new MotherBoardListPage());
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
