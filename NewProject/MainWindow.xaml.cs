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

namespace NewProject {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e) {
            if(!(e.Content is Page page)) return;
            this.Title = $"Кубарь Д. С. - {page.Title}";

            if(page is Pages.AuthPage) btnBack.Visibility = Visibility.Hidden;
            else btnBack.Visibility = Visibility.Visible;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            if(MainFrame.CanGoBack) MainFrame.GoBack();
        }
    }
}
