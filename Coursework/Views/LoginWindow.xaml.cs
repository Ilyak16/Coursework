using Coursework.Core;
using Coursework.Models;
using Coursework.Services;
using Coursework.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework.Views
{
    public partial class LoginWindow : Window
    {
        private AuthService _authService = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtuserName.Text;
            string password = txtpassword.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            var user = _authService.Login(login, password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            // сохраняем пользователя в сессию
            Session.CurrentUser = user;

            MessageBox.Show($"Вы вошли как: {user.ФИО}");

            new MainWindow().Show();
            this.Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;

            new MainWindow().Show();
            this.Close();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnLogin_Click(sender, e);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow().ShowDialog();
        }
    }
}
