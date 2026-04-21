using Coursework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coursework.Views
{
    public partial class ProductEditWindow : Window
    {
        private KupriyanovIlya2307a1HlopokContext _context = new();
        private Номенклатура _product = new();

        public ProductEditWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            if (!decimal.TryParse(tbPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Некорректная цена");
                return;
            }

            _product.Название = tbName.Text;
            _product.ПлановаяСтоимость = price;

            if (_product.ИдентификаторНоменклатуры == 0)
                _context.Номенклатураs.Add(_product);

            _context.SaveChanges();

            MessageBox.Show("Сохранено");
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
