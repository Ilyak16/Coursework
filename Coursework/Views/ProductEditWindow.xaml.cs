using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class ProductEditWindow : Window
    {
        private readonly
        KupriyanovIlya2307a1HlopokContext
            _context = new();

        public ProductEditWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (!decimal.TryParse(
                tbPrice.Text,
                out decimal price))
            {
                MessageBox.Show(
                    "Некорректная цена");

                return;
            }

            Номенклатура product =
                new Номенклатура
                {
                    Название = tbName.Text,

                    ПлановаяСтоимость = price
                };

            _context.Номенклатураs
                .Add(product);

            _context.SaveChanges();

            MessageBox.Show(
                "Товар добавлен");

            Close();
        }
    }
}