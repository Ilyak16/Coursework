using Coursework.Core;
using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Coursework.Views
{
    public partial class CartWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public CartWindow(List<CartItem> cart)
        {
            InitializeComponent();
            CartItems = cart;
            LoadCart();
        }

        private void LoadCart()
        {
            var cartData = CartItems.Select(item => new
            {
                item.Id,
                item.Название,
                item.Цена,
                item.Количество,
                Сумма = item.Цена * item.Количество
            }).ToList();

            dgCart.ItemsSource = cartData;
            tbTotal.Text = CartItems.Sum(x => x.Цена * x.Количество).ToString("F2") + " ₽";
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (CartItems.Count == 0)
            {
                MessageBox.Show("Корзина пуста");
                return;
            }

            try
            {
                var order = new Заказ
                {
                    ИдентификаторКлиента = Session.CurrentUser.Id,
                    Дата = DateTime.Now,
                    Статус = "Создан",
                    ОбщаяСтоимость = CartItems.Sum(x => x.Цена * x.Количество)
                };

                foreach (var item in CartItems)
                {
                    order.ПозицияЗаказаs.Add(new ПозицияЗаказа
                    {
                        ИдентификаторНоменклатуры = item.Id,
                        Количество = item.Количество,
                        Стоимость = item.Цена,
                        Скидка = 0
                    });
                }

                _context.Заказs.Add(order);
                _context.SaveChanges();

                MessageBox.Show($"Заказ №{order.ИдентификаторЗаказа} оформлен!\nСумма: {order.ОбщаяСтоимость:F2} ₽");
                CartItems.Clear();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Название { get; set; }
        public decimal Цена { get; set; }
        public int Количество { get; set; }
    }
}