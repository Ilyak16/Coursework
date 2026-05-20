using Coursework.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Coursework.Views
{
    public partial class OrderEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private Заказ _entity;

        public OrderEditWindow(Заказ order = null)
        {
            InitializeComponent();

            cbClient.ItemsSource = _context.Клиентs.ToList();

            if (order == null)
            {
                _entity = new Заказ
                {
                    Дата = DateTime.Now,
                    Статус = "Новый",
                    ОбщаяСтоимость = 0
                };
                Title = "Добавление заказа";
                dpDate.SelectedDate = DateTime.Now;
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                _entity = order;
                Title = "Редактирование заказа";

                var client = _context.Клиентs.Find(_entity.ИдентификаторКлиента);
                if (client != null)
                    cbClient.SelectedItem = client;

                dpDate.SelectedDate = _entity.Дата;

                foreach (ComboBoxItem item in cbStatus.Items)
                {
                    if (item.Content.ToString() == _entity.Статус)
                    {
                        cbStatus.SelectedItem = item;
                        break;
                    }
                }
            }

            // ИСПРАВЛЕНИЕ: используем ?? 0 для обработки null
            tbTotalPrice.Text = (_entity.ОбщаяСтоимость ?? 0).ToString("F2");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedClient = cbClient.SelectedItem as Клиент;
                if (selectedClient == null)
                {
                    MessageBox.Show("Выберите клиента");
                    return;
                }

                if (dpDate.SelectedDate == null)
                {
                    MessageBox.Show("Выберите дату");
                    return;
                }

                _entity.ИдентификаторКлиента = selectedClient.ИдентификаторКлиента;
                _entity.Дата = dpDate.SelectedDate.Value;
                _entity.Статус = ((ComboBoxItem)cbStatus.SelectedItem).Content.ToString();

                // Убедимся, что ОбщаяСтоимость не null
                if (_entity.ОбщаяСтоимость == null)
                    _entity.ОбщаяСтоимость = 0;

                if (_entity.ИдентификаторЗаказа == 0)
                    _context.Заказs.Add(_entity);

                _context.SaveChanges();
                MessageBox.Show("Сохранено успешно!");
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}