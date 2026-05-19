using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coursework.Views
{
    public partial class OrdersWindow : Window
    {
        private readonly
        KupriyanovIlya2307a1HlopokContext
            _context = new();

        public OrdersWindow()
        {
            InitializeComponent();

            OrdersGrid.ItemsSource =
                _context.Заказs.ToList();
        }

        private void Approve_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem
                is Заказ order)
            {
                order.Статус =
                    "Одобрен";

                _context.SaveChanges();

                MessageBox.Show(
                    "Заказ одобрен");
            }
        }
    }
}
