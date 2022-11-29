﻿using ProjectKukushkin.ClassFolder;
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

namespace ProjectKukushkin.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=Kukushkin;Integrated Security=True");
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(
                    "SELECT * From dbo.[User] " +
                    $"Where UserPassword='{LoginTb.Text}'",
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                if (dataReader[2].ToString() != PasswordTb.Text)
                {
                    MBClass.ErrorMB("Неверный пароль");
                    PasswordTb.Focus();
                }
                else
                {
                    switch (dataReader[3].ToString())
                    {
                        case "1":
                            StartWindow.OpenPage(new AdminPageFolder.AdminPage());
                            break;
                        case "2":
                            StartWindow.OpenPage(new CarFolder.CarAdminPage());
                            break;
                        case "3":
                            break;
                    }
                }
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

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.OpenPage(new RegistrationPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
