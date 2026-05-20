using Coursework.Models;
using Microsoft.EntityFrameworkCore; // ⚠️ Обязательно!
using System.Linq;
using System.Windows;

namespace Coursework.Views
{
    public partial class OrderDetailsWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();

        public OrderDetailsWindow(int orderId)
        {
            InitializeComponent();
            LoadOrderDetails(orderId);
        }

        private void LoadOrderDetails(int orderId)
        {
            // Загружаем заказ с клиентом и позициями (и товарами внутри позиций)
            var order = _context.Заказs
                .Include(z => z.ИдентификаторКлиентаNavigation)
                .Include(z => z.ПозицияЗаказаs)
                    .ThenInclude(p => p.ИдентификаторНоменклатурыNavigation)
                .FirstOrDefault(z => z.ИдентификаторЗаказа == orderId);

            if (order == null)
            {
                MessageBox.Show("Заказ не найден");
                Close();
                return;
            }

            // Заполняем шапку
            tbOrderId.Text = $"Заказ №{order.ИдентификаторЗаказа}";
            tbClientInfo.Text = $"Клиент: {order.ИдентификаторКлиентаNavigation?.ФиоИлиНазваниеКомпании ?? "Не указан"}";
            tbDate.Text = $"Дата: {order.Дата:dd.MM.yyyy HH:mm}";
            tbStatus.Text = $"Статус: {order.Статус}";
            tbTotalPrice.Text = $"Общая стоимость: {order.ОбщаяСтоимость:F2} ₽";

            // Заполняем таблицу позиций
            dgItems.ItemsSource = order.ПозицияЗаказаs.Select(p => new
            {
                НазваниеТовара = p.ИдентификаторНоменклатурыNavigation?.Название ?? "Неизвестно",
                p.Количество,
                p.Стоимость
            }).ToList();
        }
    }
}