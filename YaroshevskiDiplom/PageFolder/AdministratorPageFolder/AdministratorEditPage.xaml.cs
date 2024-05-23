using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace YaroshevskiDiplom.PageFolder.AdministratorPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AdministratorEditPage.xaml
    /// </summary>
    public partial class AdministratorEditPage : Page
    {
        string saveLogin = "";
        User user = new User();
        public AdministratorEditPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            this.user.IdUser = user.IdUser;
            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
            LoginTB.Text = saveLogin = user.LoginUser;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var checkLoginUser = DBEntities.GetContext()
                .User.FirstOrDefault(u => u.LoginUser == LoginTB.Text);
            if (checkLoginUser != null && saveLogin != LoginTB.Text)
            {
                MBClass.ErrorMB("Такой логин уже существует");
                LoginTB.Focus();
                return;
            }
            else
            {
            try
                {
                    user = DBEntities.GetContext().User
                        .FirstOrDefault(u => u.IdUser == user.IdUser);
                    user.LoginUser = LoginTB.Text;
                    user.PasswordUser = PasswordTB.Text;
                    user.IdRole = Int32.Parse(
                        RoleCb.SelectedValue.ToString());
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Данные успешно отредактированы");
                    NavigationService.Navigate(new AdministratorListPage());
                }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            }
        }
    }
}
