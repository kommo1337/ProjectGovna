﻿using ProjectKukushkin.ClassFolder;
using ProjectKukushkin.PageFolder;
using ProjectKukushkin;
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
using System.Windows.Shapes;
using System.Xml;

namespace ProjectKukushkin.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        XmlDocument load;
        XmlElement xmlElement;
        AuthorizationPage page;

        public StartWindow()
        {
            InitializeComponent();
            page = new AuthorizationPage();
            MainFrame.Navigate(page);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void RollUpIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        public static void OpenPage(Page page)
        {
            ((StartWindow)App.Current.MainWindow).MainFrame.Navigate(page);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
