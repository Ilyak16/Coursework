using Coursework.Core;
using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Coursework.Views
{
    public partial class MainWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();

        // Поле для корзины
        private List<CartItem> _cart = new List<CartItem>();

        public MainWindow()
        {
            InitializeComponent();
            tbUser.Text = Session.CurrentUser?.ФИО ?? "Гость";
            SetupPermissions();
            LoadData();
        }

        private void SetupPermissions()
        {
            if (Session.CurrentRole != Role.Admin)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                btnAdmin.Visibility = Visibility.Collapsed;
                dgProducts.IsReadOnly = true;
            }
        }

        private void LoadData(string search = "")
        {
            var query = _context.Номенклатураs.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Название.Contains(search));
            }

            dgProducts.ItemsSource = query.Select(x => new
            {
                x.ИдентификаторНоменклатуры,
                x.Название,
                Цена = x.ПлановаяСтоимость,
                Количество = x.Запасыs.Sum(z => z.Количество)
            }).ToList();
        }

        private void Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LoadData(tbSearch.Text);
        }

        // Открытие окна корзины
        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            var cartWindow = new CartWindow(_cart);
            cartWindow.ShowDialog();
            tbCartCount.Text = $"Корзина: {_cart.Sum(x => x.Количество)}";
        }

        // Добавление товара в корзину
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            dynamic selectedRow = dgProducts.SelectedItem;
            int productId = selectedRow.ИдентификаторНоменклатуры;
            string productName = selectedRow.Название;
            decimal price = selectedRow.Цена;

            var existingItem = _cart.FirstOrDefault(x => x.Id == productId);
            if (existingItem != null)
            {
                existingItem.Количество++;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    Id = productId,
                    Название = productName,
                    Цена = price,
                    Количество = 1
                });
            }

            tbCartCount.Text = $"Корзина: {_cart.Sum(x => x.Количество)}";
            MessageBox.Show($"Товар '{productName}' добавлен в корзину");
        }

        // Оформление заказа
        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста. Добавьте товары.");
                return;
            }

            var cartWindow = new CartWindow(_cart);
            if (cartWindow.ShowDialog() == true)
            {
                tbCartCount.Text = "Корзина: 0";
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Session.CurrentRole != Role.Admin) return;
            new ProductEditWindow().ShowDialog();
            LoadData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Session.CurrentRole != Role.Admin) return;
            dynamic selected = dgProducts.SelectedItem;
            if (selected == null) return;

            int id = selected.ИдентификаторНоменклатуры;
            var product = _context.Номенклатураs.Find(id);

            if (_context.ПозицияЗаказаs.Any(x => x.ИдентификаторНоменклатуры == id))
            {
                MessageBox.Show("Товар есть в заказах");
                return;
            }

            if (MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _context.Номенклатураs.Remove(product);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            if (Session.CurrentRole != Role.Admin) return;
            new AdminWindow().ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;
            new LoginWindow().Show();
            Close();
        }
    }
    // УДАЛИТЕ отсюда класс CartItem - он уже есть в CartWindow.xaml.cs!
}