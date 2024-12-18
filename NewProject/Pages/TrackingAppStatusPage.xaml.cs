using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static NewProject.Connection;

namespace NewProject.Pages {
    /// <summary>
    /// Логика взаимодействия для TrackingAppStatusPage.xaml
    /// </summary>
    public partial class TrackingAppStatusPage :Page {
        public TrackingAppStatusPage() {
            InitializeComponent();
            try {
                

                dgApps.ItemsSource = GetContext().Application.ToList();

                cbClient.ItemsSource = GetContext().Client.Select(x => x.ClientName).ToList();
                cbStatus.ItemsSource = GetContext().AppStatus.Select(x => x.StatusName).ToList();
                cbWorker.ItemsSource = GetContext().Worker.Select(x => x.WorkerName).ToList();
            }
            catch {
                MessageBox.Show("При загрузке данных произошла ошибка");
            }
        }

        private void tbAppNum_TextChanged(object sender, TextChangedEventArgs e) {
            ChangeData();
        }

        private void cbClient_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ChangeData();
        }

        private void cbWorker_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ChangeData();
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ChangeData();
        }

        public void ChangeData() {
            try {
                
                var items   = GetContext().Application.ToList();

                if(tbAppNum.Text != string.Empty) {
                    items = items.Where(x => x.Id == int.Parse(tbAppNum.Text)).ToList();
                }

                if(cbClient.SelectedItem != null) {
                    items = items.Where(x => x.Client ==
                    int.Parse(GetContext().Client.Where(y => cbClient.SelectedItem.ToString() == y.ClientName).Select(y => y.Id).First().ToString())
                    ).ToList();
                }

                if(cbWorker.SelectedItem != null) {
                    items = items.Where(x => x.Responsible ==
                    int.Parse(GetContext().Worker.Where(y => cbWorker.SelectedItem.ToString() == y.WorkerName).Select(y => y.Id).First().ToString())
                    ).ToList();
                }

                if(cbStatus.SelectedItem != null) {
                    items = items.Where(x => x.AppStatus ==
                    int.Parse(GetContext().AppStatus.Where(y => cbStatus.SelectedItem.ToString() == y.StatusName).Select(y => y.Id).First().ToString())
                    ).ToList();
                }

                dgApps.ItemsSource = null;
                dgApps.ItemsSource = items;
            }
            catch {
                MessageBox.Show("При обновлении данных произошла ошибка");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            tbAppNum.Text         = string.Empty;
            cbClient.SelectedItem = null;
            cbStatus.SelectedItem = null;
            cbWorker.SelectedItem = null;
            try {
                

                dgApps.ItemsSource = GetContext().Application.ToList();
            }
            catch {
                MessageBox.Show("При загрузке данных произошла ошибка");
            }
        }
    }
}
