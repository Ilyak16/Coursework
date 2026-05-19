using Coursework.Models;
using Coursework.Services;
using System.Windows;

namespace Coursework.Views
{
    public partial class RegisterWindow : Window
    {
        private readonly
        KupriyanovIlya2307a1HlopokContext
            _context = new();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(
            object sender,
            RoutedEventArgs e)
        {
            string fullName =
                FullNameBox.Text.Trim();

            string login =
                LoginBox.Text.Trim();

            string password =
                PasswordBox.Password;

            string repeatPassword =
                RepeatPasswordBox.Password;

            if (
                string.IsNullOrWhiteSpace(fullName)
                || string.IsNullOrWhiteSpace(login)
                || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Заполните все поля");

                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show(
                    "Пароль слишком короткий");

                return;
            }

            if (password != repeatPassword)
            {
                MessageBox.Show(
                    "Пароли не совпадают");

                return;
            }

            bool exists =
                _context.Пользовательs
                .Any(x => x.Логин == login);

            if (exists)
            {
                MessageBox.Show(
                    "Пользователь уже существует");

                return;
            }

            Пользователь user =
                new Пользователь
                {
                    ФИО = fullName,

                    Логин = login,

                    Пароль =
                        HashService
                        .ComputeSha512(password),

                    Роль = "Client"
                };

            _context.Пользовательs
                .Add(user);

            _context.SaveChanges();

            MessageBox.Show(
                "Регистрация успешна");

            new LoginWindow().Show();

            Close();
        }
    }
}