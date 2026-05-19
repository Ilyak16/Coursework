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
        private readonly
            AuthService _auth =
            new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(
            object sender,
            RoutedEventArgs e)
        {
            var user =
                _auth.Login(
                    LoginBox.Text,
                    PasswordBox.Password);

            if (user == null)
            {
                MessageBox.Show(
                    "Неверный логин или пароль");

                return;
            }

            Session.CurrentUser = user;

            switch (Session.CurrentRole)
            {
                case Role.Admin:

                    new AdminWindow().Show();
                    break;

                case Role.Manager:

                    new OrdersWindow().Show();
                    break;

                default:

                    new MainWindow().Show();
                    break;
            }

            Close();
        }

        private void Register_Click(
            object sender,
            RoutedEventArgs e)
        {
            new RegisterWindow().Show();

            Close();
        }
    }
}
