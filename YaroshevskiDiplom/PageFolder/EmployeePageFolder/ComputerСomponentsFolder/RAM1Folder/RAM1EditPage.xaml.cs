﻿using System;
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
using YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputersFolder;

namespace YaroshevskiDiplom.PageFolder.EmployeePageFolder.ComputerСomponentsFolder.RAM1Folder
{
    /// <summary>
    /// Логика взаимодействия для RAM1EditPage.xaml
    /// </summary>
    public partial class RAM1EditPage : Page
    {
        private RAM1 originalRAM1;
        public RAM1EditPage(RAM1 ram1)
        {
            InitializeComponent();
            originalRAM1 = DBEntities.GetContext().RAM1
                .FirstOrDefault(u => u.IdRAM1 == ram1.IdRAM1);
            DataContext = originalRAM1;
            this.originalRAM1.IdRAM1 = originalRAM1.IdRAM1;
            RAMCb.ItemsSource = DBEntities.GetContext()
                .RAM.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                originalRAM1 = DBEntities.GetContext().RAM1
                        .FirstOrDefault(u => u.IdRAM1 == originalRAM1.IdRAM1);
                originalRAM1.IdRAM = Int32.Parse(
                    RAMCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new RAM1ListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
