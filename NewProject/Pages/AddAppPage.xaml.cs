using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
using System.Xml.Linq;
using static NewProject.Connection;

namespace NewProject.Pages {
    /// <summary>
    /// Логика взаимодействия для AddAppPage.xaml
    /// </summary>
    public partial class AddAppPage :Page {
        public AddAppPage(Worker worker) {
            InitializeComponent();

            if(worker.WorkerRole == 1) {
                lblWorker.Visibility = Visibility.Visible;
                cbWorker.Visibility  = Visibility.Visible;
            }
            else {
                lblWorker.Visibility = Visibility.Collapsed;
                cbWorker.Visibility  = Visibility.Collapsed;
            }

            try {
                

                cbClient.ItemsSource      = GetContext().Client.Select(x => x.ClientName).ToList();
                cbEquipment.ItemsSource    = GetContext().Equipment.Select(x => x.EquipmentName).ToList();
                cbDeffectType.ItemsSource = GetContext().DeffectType.Select(x => x.DeffectName).ToList();
                cbAppStatus.ItemsSource   = GetContext().AppStatus.Select(x => x.StatusName).ToList();
                cbWorker.ItemsSource      = GetContext().Worker.Select(x => x.WorkerName).ToList();
            }
            catch {
                MessageBox.Show("При загрузке данных произошла ошибка");
            }
            
        }

        private void btnAddApplication_Click(object sender, RoutedEventArgs e) {
            if(string.IsNullOrEmpty(tbDateOfAdd.Text) ||
                string.IsNullOrEmpty(cbDeffectType.Text) ||
                string.IsNullOrEmpty(tbDescription.Text) ||
                string.IsNullOrEmpty(cbClient.Text) ||
                string.IsNullOrEmpty(cbAppStatus.Text) ||
                string.IsNullOrEmpty(cbWorker.Text) ||
                string.IsNullOrEmpty(tbComment.Text) ||
                string.IsNullOrEmpty(tbDueDate.Text) ||
                string.IsNullOrEmpty(tbAppNum.Text)
                ) {
                MessageBox.Show("Не все поля для регистрации заполнены!");
                return;
            }

            try {
                
                var Application = new Application {
                    Id             = int.Parse(tbAppNum.Text),
                    DateOfAdd      = DateTime.Parse(tbDateOfAdd.Text),
                    DeffectType    = int.Parse(GetContext().DeffectType.Where(x => cbDeffectType.Text == x.DeffectName).Select(x => x.Id).First().ToString()),
                    AppDescription = tbDescription.Text,
                    Client         = int.Parse(GetContext().Client.Where(x => cbClient.Text == x.ClientName).Select(x => x.Id).First().ToString()),
                    AppStatus      = int.Parse(GetContext().AppStatus.Where(x => cbAppStatus.Text == x.StatusName).Select(x => x.Id).First().ToString()),
                    Responsible    = int.Parse(GetContext().Worker.Where(x => cbWorker.Text == x.WorkerName).Select(x => x.Id).First().ToString()),
                    Comment        = tbComment.Text,
                    DueDate        = DateTime.Parse(tbDueDate.Text)
                };

                GetContext().Application.Add(Application);
                //GetContext().SaveChanges();
                SaveContext(GetContext());

                MessageBox.Show("Заявка успешно добавлена!");

                tbAppNum.Text              = string.Empty;
                tbDateOfAdd.Text           = string.Empty;
                cbDeffectType.SelectedItem = null;
                tbDescription.Text         = string.Empty;
                cbClient.SelectedItem      = null;
                cbAppStatus.SelectedItem   = null;
                cbWorker.SelectedItem      = null;
                tbComment.Text             = string.Empty;
                tbDueDate.Text             = string.Empty;
            }
            catch (Exception ex) {
                MessageBox.Show($"При создании заявки произошла ошибка: {ex.Message}");
            }
            
        }
    }
}
