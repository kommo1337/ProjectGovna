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
    /// Логика взаимодействия для ClientAddPage1xaml.xaml
    /// </summary>
    public partial class ClientAddPage1xaml : Page
    {
        CBClass cBClass;
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=Kukushkin;Integrated Security=True");
        SqlCommand sqlCommand;
        public ClientAddPage1xaml()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.LoadCB(MarkCb, CBClass.CBType.Mark);
            cBClass.LoadCB(UserNameTb, CBClass.CBType.UserName);
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {          
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert Into dbo.[Client] " +
                "(CarId,ClientName,ClientSecondName,ClientLastName," +
                "ClientNumber,DLNumber,DLEpisode,DateOut,UserId) " +
                $"Values ('{MarkCb.SelectedValue.ToString()}'," +
                $"'{NameTb.Text}'," +
                $"'{SecondNameTb.Text}'," +
                $"'{LastNameTb.Text}'," +
                $"'{EmailTb.Text}'," +
                $"'{NumberTb.Text}'," +
                $"'{EpisodeTb.Text}'," +
                $"'{DateTb.Text}'," +
                $"'{UserNameTb.SelectedValue.ToString()}')",
                sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InfoMB($"Пользователь " +
                $"успешно добавлен");
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
            StartWindow.OpenPage(new ClientAdminPage());
        }
    }
}
