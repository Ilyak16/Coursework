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
using Coursework.Models;
using Coursework.Views;

namespace Coursework.Views
{
    public partial class MainWindow : Window
    {
        private List<User> _users = new List<User>
    {
        new User { userName = "admin", password = "admin123", role = "Admin" },
        new User { userName = "user", password = "user123", role = "User" },
        new User { userName = "manager", password = "123", role = "Manager" }
    };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guest guest = new Guest();
            guest.ShowDialog();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtuserName.Text;
            string password = txtpassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("!!!");
                return;
            }

            var user = _users.FirstOrDefault(u => u.userName == username && u.password == password);

            if (user != null && user.role == "Manager")
            {
                ManagerWindow userWindow = new ManagerWindow();
                userWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("!!!");
            }
        }
    }
}
