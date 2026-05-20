using Coursework.Core;
using Coursework.Models;
using Coursework.Views; // Важно: подключить пространство имен с окнами
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Coursework.Views
{
    public partial class AdminWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();

        public AdminWindow()
        {
            InitializeComponent();
            if (Session.CurrentRole != Role.Admin)
            {
                MessageBox.Show("Нет доступа");
                Close();
                return;
            }
            TablesBox.ItemsSource = new List<string>
            {
                "Пользователь", "Заказ", "Номенклатура", "КатегорияТоваров",
                "ТипРабот", "ТипТехники", "Ресурс"
            };
        }

        private void TablesBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string table = TablesBox.SelectedItem?.ToString();

            // Показываем кнопку "Детали заказа" только для таблицы Заказ
            if (table == "Заказ")
                btnOrderDetails.Visibility = Visibility.Visible;
            else
                btnOrderDetails.Visibility = Visibility.Collapsed;

            switch (table)
            {
                case "Пользователь":
                    AdminGrid.ItemsSource = _context.Пользовательs.ToList();
                    break;
                case "Заказ":
                    AdminGrid.ItemsSource = _context.Заказs.ToList();
                    break;
                case "Номенклатура":
                    AdminGrid.ItemsSource = _context.Номенклатураs.ToList();
                    break;
                case "КатегорияТоваров":
                    AdminGrid.ItemsSource = _context.КатегорияТоваровs.ToList();
                    break;
                case "ТипРабот":
                    AdminGrid.ItemsSource = _context.ТипРаботs.ToList();
                    break;
                case "ТипТехники":
                    AdminGrid.ItemsSource = _context.ТипТехникиs.ToList();
                    break;
                case "Ресурс":
                    AdminGrid.ItemsSource = _context.Ресурсs.ToList();
                    break;
            }
        }

        // Метод для обновления таблицы (вызывается при смене в ComboBox и после редактирования)
        private void RefreshGrid()
        {
            string table = TablesBox.SelectedItem?.ToString();
            switch (table)
            {
                case "Пользователь":
                    AdminGrid.ItemsSource = _context.Пользовательs.ToList();
                    break;
                case "Заказ":
                    AdminGrid.ItemsSource = _context.Заказs.ToList();
                    break;
                case "Номенклатура":
                    AdminGrid.ItemsSource = _context.Номенклатураs.ToList();
                    break;
                case "КатегорияТоваров":
                    AdminGrid.ItemsSource = _context.КатегорияТоваровs.ToList();
                    break;
                case "ТипРабот":
                    AdminGrid.ItemsSource = _context.ТипРаботs.ToList();
                    break;
                case "ТипТехники":
                    AdminGrid.ItemsSource = _context.ТипТехникиs.ToList();
                    break;
                case "Ресурс":
                    AdminGrid.ItemsSource = _context.Ресурсs.ToList();
                    break;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string tableName = TablesBox.SelectedItem?.ToString();
            if (tableName == null) return;

            try
            {
                switch (tableName)
                {
                    case "Номенклатура":
                        var product = AdminGrid.SelectedItem as Номенклатура;
                        new NomenclatureEditWindow(product).ShowDialog();
                        break;

                    case "Пользователь":
                        var user = AdminGrid.SelectedItem as Пользователь;
                        new UserEditWindow(user).ShowDialog();
                        break;

                    case "КатегорияТоваров":
                        var category = AdminGrid.SelectedItem as КатегорияТоваров;
                        new CategoryEditWindow(category).ShowDialog();
                        break;

                    case "ТипРабот":
                        var workType = AdminGrid.SelectedItem as ТипРабот;
                        new WorkTypeEditWindow(workType).ShowDialog();
                        break;

                    case "ТипТехники":
                        var equipType = AdminGrid.SelectedItem as ТипТехники;
                        new EquipmentTypeEditWindow(equipType).ShowDialog();
                        break;

                    case "Ресурс":
                        var resource = AdminGrid.SelectedItem as Ресурс;
                        new ResourceEditWindow(resource).ShowDialog();
                        break;

                    case "Заказ":
                        var order = AdminGrid.SelectedItem as Заказ;
                        new OrderEditWindow(order).ShowDialog();
                        break;

                    default:
                        MessageBox.Show("Редактирование для этой таблицы пока не настроено");
                        return;
                }

                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ViewOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItem is Заказ order)
            {
                new OrderDetailsWindow(order.ИдентификаторЗаказа).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите заказ в таблице");
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItem == null) return;
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            try
            {
                _context.Remove(AdminGrid.SelectedItem);
                _context.SaveChanges();
                MessageBox.Show("Удалено");
                RefreshGrid();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить запись (есть связанные данные)");
            }
        }
    }
}