using Coursework.Models;
using Coursework.Services;
using Microsoft.Data.SqlClient; // ← Правильный namespace для SqlException
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Coursework.Views
{
    public partial class UserEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private Пользователь _entity;
        private bool _isNew; // Флаг: новый пользователь или редактирование

        public UserEditWindow(Пользователь user = null)
        {
            InitializeComponent();

            if (user == null)
            {
                _entity = new Пользователь();
                _isNew = true;
                Title = "Добавление пользователя";
                cbRole.SelectedIndex = 0;
            }
            else
            {
                _entity = user;
                _isNew = false;
                Title = "Редактирование пользователя";
                tbFio.Text = _entity.ФИО;
                tbLogin.Text = _entity.Логин;

                // Выбираем роль в ComboBox
                foreach (ComboBoxItem item in cbRole.Items)
                {
                    if (item.Content.ToString() == _entity.Роль)
                    {
                        cbRole.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(tbFio.Text) || string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Заполните ФИО и логин");
                return;
            }

            if (!_isNew && !string.IsNullOrEmpty(pbPassword.Password) && pbPassword.Password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов");
                return;
            }
            if (_isNew && (string.IsNullOrEmpty(pbPassword.Password) || pbPassword.Password.Length < 6))
            {
                MessageBox.Show("Введите пароль (минимум 6 символов)");
                return;
            }

            try
            {
                _entity.ФИО = tbFio.Text;
                _entity.Логин = tbLogin.Text;

                if (cbRole.SelectedItem is ComboBoxItem selectedItem)
                {
                    _entity.Роль = selectedItem.Content.ToString();
                }

                // Пароль: меняем только если ввели новый
                if (!string.IsNullOrEmpty(pbPassword.Password))
                {
                    _entity.Пароль = HashService.ComputeSha512(pbPassword.Password);
                }

                if (_isNew)
                {
                    // Проверяем уникальность логина перед добавлением
                    if (_context.Пользовательs.Any(x => x.Логин == _entity.Логин))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        return;
                    }
                    _context.Пользовательs.Add(_entity);
                }
                // Если редактируем — сущность уже отслеживается, SaveChanges() обновит её

                _context.SaveChanges();
                MessageBox.Show("Сохранено!");
                Close();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Дубликат уникального индекса/ключа
                MessageBox.Show("Пользователь с таким логином уже существует!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}