using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coursework.Views
{
    public partial class RegisterWindow : Window
    {
        private KupriyanovIlya2307a1HlopokContext _context = new();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (_context.Пользовательs.Any(x => x.Логин == tbLogin.Text))
            {
                MessageBox.Show("Логин уже существует");
                return;
            }

            var user = new Пользователь
            {
                Логин = tbLogin.Text,
                Пароль = tbPassword.Password,
                ФИО = tbName.Text,
                Роль = "Клиент"
            };

            _context.Пользовательs.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Регистрация успешна");
            this.Close();
        }
    }
}
