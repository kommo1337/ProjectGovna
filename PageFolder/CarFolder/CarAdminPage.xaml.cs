using ProjectKukushkin.ClassFolder;
using ProjectKukushkin.PageFolder.AdminPageFolder;
using ProjectKukushkin.WindowFolder;
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

namespace ProjectKukushkin.PageFolder.CarFolder
{
    /// <summary>
    /// Логика взаимодействия для CarAdminPage.xaml
    /// </summary>
    public partial class CarAdminPage : Page
    {
        DGClass dG;
        public CarAdminPage()
        {
            InitializeComponent();
            dG = new DGClass(ListUserDG);
        }
        private void BackIm_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new AuthorizationPage());
        }

        private void ListUserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    VarialbleClass.UserId = dG.SelectId();
                    StartWindow.OpenPage(new EditCarPage());
                    dG.LoadDG("Select * From dbo.[Car]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dG.LoadDG("Select * From dbo.[Car] " +
                $"Where Mark Like '%{SearchTb.Text}%'");
        }

        private void AddIm_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new AddCarPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dG.LoadDG("SELECT * From dbo.[Car]");
        }
    }
}
