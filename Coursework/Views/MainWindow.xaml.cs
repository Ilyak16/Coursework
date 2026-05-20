using Coursework.Core;
using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class MainWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        // Список для хранения товаров в корзине
        private List<ПозицияЗаказа> _cart = new List<ПозицияЗаказа>();

        public MainWindow()
        {
            InitializeComponent();
            tbUser.Text = Session.CurrentUser?.ФИО ?? "Гость";
            SetupPermissions();
            LoadData();
        }

        private void SetupPermissions()
        {
            // Если не админ, скрываем админские кнопки
            if (Session.CurrentRole != Role.Admin)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                btnAdmin.Visibility = Visibility.Collapsed;
                // Убираем возможность редактировать сетку
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

            // Формируем список для отображения
            dgProducts.ItemsSource = query.Select(x => new
            {
                x.ИдентификаторНоменклатуры, // Важно: нужен ID для заказа
                x.Название,
                Цена = x.ПлановаяСтоимость,
                Количество = x.Запасыs.Sum(z => z.Количество)
            }).ToList();
        }

        private void Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LoadData(tbSearch.Text);
        }

        // Логика добавления в корзину
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            // Получаем ID выбранного товара (так как мы используем анонимный тип)
            dynamic selectedRow = dgProducts.SelectedItem;
            int productId = selectedRow.ИдентификаторНоменклатуры;
            string productName = selectedRow.Название;
            decimal price = selectedRow.Цена;

            // Добавляем в список корзины
            _cart.Add(new ПозицияЗаказа
            {
                ИдентификаторНоменклатуры = productId,
                Количество = 1, // По умолчанию 1
                Стоимость = price
            });

            tbCartCount.Text = $"Корзина: {_cart.Count}";
            MessageBox.Show($"Товар '{productName}' добавлен в корзину");
        }

        // Логика оформления заказа
        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста");
                return;
            }

            try
            {
                // Создаем новый заказ
                Заказ newOrder = new Заказ
                {
                    ИдентификаторКлиента = Session.CurrentUser.Id,
                    Дата = DateTime.Now,
                    Статус = "Новый",
                    ОбщаяСтоимость = _cart.Sum(p => p.Стоимость * p.Количество)
                };

                // Добавляем позиции заказа к заказу
                foreach (var item in _cart)
                {
                    newOrder.ПозицияЗаказаs.Add(item);
                }

                _context.Заказs.Add(newOrder);
                _context.SaveChanges();

                MessageBox.Show("Заказ успешно оформлен!");
                _cart.Clear();
                tbCartCount.Text = "Корзина: 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при оформлении: " + ex.Message);
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
}