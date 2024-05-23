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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM1Folder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM2Folder
{
    /// <summary>
    /// Логика взаимодействия для RAM2AddPage.xaml
    /// </summary>
    public partial class RAM2AddPage : Page
    {
        public RAM2AddPage()
        {
            InitializeComponent();
            RAMCb.ItemsSource = DBEntities.GetContext()
                .RAM.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RAMCb.Text))
            {
                MBClass.ErrorMB("Пожалуйста, выберите оперативную память");
                RAMCb.Focus();
            }

            else
            {
                try
                {
                    DBEntities.GetContext().RAM2.Add(new RAM2()
                    {
                        IdRAM = Int32.Parse(RAMCb.SelectedValue.ToString()),
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Успешно");
                    NavigationService.Navigate(new RAM2ListPage());
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
