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
    /// Логика взаимодействия для EditCarPage.xaml
    /// </summary>
    
    public partial class EditCarPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=Kukushkin;Integrated Security=True");
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        public EditCarPage()
        {
            InitializeComponent();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new AdminPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                sqlConnection.Open();
                sqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[Car] " +
                    $"Set Model ='{ModelTb.Text}'," +
                    $"Mark='{MarkTb.Text}'," +
                    $"RegNumber='{NumberCb.Text}'," +
                    $"PricePerMinute='{PriceCb.Text}' " +
                    $"Where CarId='{VarialbleClass.UserId}'",
                    sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Данные машины " +
                    $"успешно отредактированы");
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * from dbo.[Car] " +
                    $"Where CarId='{VarialbleClass.UserId}'",
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                ModelTb.Text = dataReader[1].ToString();
                MarkTb.Text = dataReader[2].ToString();
                NumberCb.Text = dataReader[3].ToString();
                PriceCb.Text = dataReader[4].ToString();
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
    }
}
