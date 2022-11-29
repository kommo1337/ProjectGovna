using ProjectKukushkin.ClassFolder;
using ProjectKukushkin.PageFolder.AdminPageFolder;
using ProjectKukushkin.WindowFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        CBClass cBClass;
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=Kukushkin;Integrated Security=True");
        SqlCommand sqlCommand;
        public AddCarPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert Into dbo.[Car] " +
                "(Model,Mark,RegNumber,PricePerMinute) " +
                $"Values ('{ModelTb.Text}'," +
                $"'{MarkTb.Text}'," +
                $"'{NumberCb.Text}'," +
                $"'{PriceCb.Text}')",
                sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Машина " +
                $"успешно добавлена");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }           
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new CarAdminPage());
        }
    }
}
