using Coursework.Models;
using System.Linq;
using System.Windows;

namespace Coursework.Views
{
    public partial class OrdersWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();

        public OrdersWindow()
        {
            InitializeComponent();
            OrdersGrid.ItemsSource = _context.Заказs.ToList();
        }
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem is Заказ order)
            {
                new OrderDetailsWindow(order.ИдентификаторЗаказа).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите заказ в таблице");
            }
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem is Заказ order)
            {
                // Проверяем, что статус именно "Создан" (или "Новый", зависит от вашей БД)
                // На скриншоте у вас "Создан"
                if (order.Статус == "Создан" || order.Статус == "Новый")
                {
                    order.Статус = "Одобрен";
                    _context.SaveChanges();
                    MessageBox.Show("Заказ одобрен");

                    // Обновляем таблицу
                    OrdersGrid.ItemsSource = _context.Заказs.ToList();
                }
                else
                {
                    MessageBox.Show($"Нельзя изменить заказ со статусом '{order.Статус}'. Обрабатываются только новые заказы.");
                }
            }
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem is Заказ order)
            {
                // Аналогичная проверка для отклонения
                if (order.Статус == "Создан" || order.Статус == "Новый")
                {
                    if (MessageBox.Show("Отклонить заказ?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        order.Статус = "Отклонен";
                        _context.SaveChanges();
                        MessageBox.Show("Заказ отклонен");

                        // Обновляем таблицу
                        OrdersGrid.ItemsSource = _context.Заказs.ToList();
                    }
                }
                else
                {
                    MessageBox.Show($"Нельзя изменить заказ со статусом '{order.Статус}'. Обрабатываются только новые заказы.");
                }
            }
        }
    }
}