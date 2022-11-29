using ProjectKukushkin.ClassFolder;
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

namespace ProjectKukushkin.PageFolder.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для ClientEditPage.xaml
    /// </summary>
    public partial class ClientEditPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=Kukushkin;Integrated Security=True");
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        CBClass cBClass;
        public ClientEditPage()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new ClientAdminPage());
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[Client] " +
                    $"Set CarId ='{MarkCb.SelectedValue.ToString()}'," +
                    $"ClientName='{NameTb.Text}'," +
                    $"ClientSecondName='{SecondNameTb.Text}'," +
                    $"ClientLastName='{LastNameTb.Text}'," +
                    $"ClientNumber='{EmailTb.Text}'," +
                    $"DLNumber='{NumberTb.Text}'," +
                    $"DLEpisode='{EpisodeTb.Text}'," +
                    $"DateOut='{DateTb.Text}'," +
                    $"UserId='{UserNameTb.SelectedValue.ToString()}' " +
                    $"Where ClientId='{VarialbleClass.UserId}'",
                    sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Данные пользователя " +
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
            cBClass.LoadCB(MarkCb, CBClass.CBType.Mark);
            cBClass.LoadCB(UserNameTb, CBClass.CBType.UserName);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * from dbo.[Client] " +
                    $"Where ClientId='{VarialbleClass.UserId}'",
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                MarkCb.Text = dataReader[1].ToString();
                NameTb.Text = dataReader[2].ToString();
                SecondNameTb.Text = dataReader[3].ToString();
                LastNameTb.Text = dataReader[4].ToString();
                EmailTb.Text = dataReader[5].ToString();
                NumberTb.Text = dataReader[6].ToString();
                EpisodeTb.Text = dataReader[7].ToString();
                DateTb.Text = dataReader[8].ToString();
                UserNameTb.SelectedValue = dataReader[9].ToString();
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
