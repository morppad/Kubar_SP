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

namespace NewProject.Pages {
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage :Page {

        Worker worker;
        public MainPage(Worker worker) {
            InitializeComponent();

            this.worker = worker;

            if(worker.WorkerRole == 1) {
                lblUserRole.Content = "Текущая роль: менеджер";
            }
            else {
                lblUserRole.Content = "Текущая роль: пользователь";
            }
        }


        private void AddApplication_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new AddAppPage(worker));
        }

        private void EditApplication_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new EditAppPage(worker));
        }

        private void TrackingApplication_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new TrackingAppStatusPage());
        }

        private void Statistic_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new StatisticPage());
        }

        private void MarkUp_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new MarkUpPage());
        }
    }
}
