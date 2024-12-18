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
using static NewProject.Connection;

namespace NewProject.Pages {
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage :Page {
        public AuthPage() {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e) {
            Auth(LoginBox.Text, PasswordBox.Password, true);
        }

        public bool Auth(string Login, string Password, bool ByButton) {
            if(string.IsNullOrEmpty(Login) ||
               string.IsNullOrEmpty(Password)) return false;


                var Worker = GetContext().Worker
                    .AsNoTracking()
                    .FirstOrDefault(u => u.WorkerLogin == Login && u.WorkerPassword == Password);
                if(Worker == null) {
                    MessageBox.Show("Пользователя с такими данными не найден!");
                    return false;
                }
                MessageBox.Show("Пользователь успешно найден!");
                if(ByButton) NavigationService.Navigate(new MainPage(Worker));
                return true;
        }
    }
}
