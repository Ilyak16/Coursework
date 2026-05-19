using Coursework.Core;
using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coursework.Views
{
    public partial class AdminWindow : Window
    {
        private readonly
        KupriyanovIlya2307a1HlopokContext
            _context = new();

        public AdminWindow()
        {
            InitializeComponent();

            if (Session.CurrentRole
                != Role.Admin)
            {
                MessageBox.Show(
                    "Нет доступа");

                Close();
                return;
            }

            TablesBox.ItemsSource =
                new List<string>
                {
                    "Пользователь",
                    "Заказ",
                    "Номенклатура",
                    "КатегорияТоваров",
                    "ТипРабот",
                    "ТипТехники",
                    "Ресурс"
                };
        }

        private void TablesBox_SelectionChanged(
            object sender,
            System.Windows.Controls
            .SelectionChangedEventArgs e)
        {
            string table =
                TablesBox.SelectedItem
                ?.ToString();

            switch (table)
            {
                case "Пользователь":

                    AdminGrid.ItemsSource =
                        _context
                        .Пользовательs
                        .ToList();
                    break;

                case "Заказ":

                    AdminGrid.ItemsSource =
                        _context
                        .Заказs
                        .ToList();
                    break;

                case "Номенклатура":

                    AdminGrid.ItemsSource =
                        _context
                        .Номенклатураs
                        .ToList();
                    break;

                case "КатегорияТоваров":

                    AdminGrid.ItemsSource =
                        _context
                        .КатегорияТоваровs
                        .ToList();
                    break;

                case "ТипРабот":

                    AdminGrid.ItemsSource =
                        _context
                        .ТипРаботs
                        .ToList();
                    break;

                case "ТипТехники":

                    AdminGrid.ItemsSource =
                        _context
                        .ТипТехникиs
                        .ToList();
                    break;

                case "Ресурс":

                    AdminGrid.ItemsSource =
                        _context
                        .Ресурсs
                        .ToList();
                    break;
            }
        }

        private void Save_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                _context.SaveChanges();

                MessageBox.Show(
                    "Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void Delete_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (AdminGrid.SelectedItem
                == null)
                return;

            if (MessageBox.Show(
                "Удалить запись?",
                "Подтверждение",
                MessageBoxButton.YesNo)
                != MessageBoxResult.Yes)
                return;

            try
            {
                _context.Remove(
                    AdminGrid.SelectedItem);

                _context.SaveChanges();

                MessageBox.Show(
                    "Удалено");
            }
            catch
            {
                MessageBox.Show(
                    "Нельзя удалить запись");
            }
        }
    }
}
