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
    /// Логика взаимодействия для StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage :Page {
        public StatisticPage() {
            InitializeComponent();
            try {
                

                lblQuantity.Content = "Количество выполненных заявок: " + GetContext().Application.Where(x => x.DateOfEnd != null).Select(x => x).ToList().Count;
                lblAvarage.Content  = "Среднее время выполнения заявки: " + Aver().ToString(); 
                    
                var RawItems = GetContext().Application.GroupBy(x => x.DeffectType, x => 1).Select(y => new { 
                    DeffectType = y.Key, Quantity = y.Sum()
                }).ToList();

                Dictionary<string, int> Dict = new Dictionary<string, int>();

                foreach (var item in RawItems) {
                    Dict.Add(GetContext().DeffectType.Where(x => x.Id == item.DeffectType).Select(x => x.DeffectName).ToList()[0].ToString(), item.Quantity);
                }

                var Items = Dict.Select(x => new { DeffectType = x.Key, Quantity = x.Value });
                lstStatistic.ItemsSource = Items;
            }
            catch {
                MessageBox.Show("При загрузке данных произошла ошибка");
            }
        }
        public double Aver() {
            try {
                List<Application> apps = GetContext().Application.Select(x => x).ToList();
                double sum             = 0;
                double count           = 0;

                foreach(Application app in apps) {
                    if(app.DateOfEnd != null) {
                        sum += app.DateOfEnd.Value.Subtract(app.DateOfAdd).TotalHours;
                        count++;
                    }
                }

                return sum / count;
            }
            catch {
                MessageBox.Show("При загрузке данных произошла ошибка");
                return 0;
            }
        }
    }
}
