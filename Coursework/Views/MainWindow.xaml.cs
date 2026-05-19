using Coursework.Core;
using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class MainWindow : Window
    {
        private readonly
        KupriyanovIlya2307a1HlopokContext
            _context = new();

        public MainWindow()
        {
            InitializeComponent();

            tbUser.Text =
                Session.CurrentUser?.ФИО
                ?? "Гость";

            SetupPermissions();

            LoadData();
        }

        private void SetupPermissions()
        {
            if (Session.CurrentRole
                != Role.Admin)
            {
                btnAdd.Visibility =
                    Visibility.Collapsed;

                btnDelete.Visibility =
                    Visibility.Collapsed;

                btnAdmin.Visibility =
                    Visibility.Collapsed;
            }
        }

        private void LoadData(
            string search = "")
        {
            var query =
                _context.Номенклатураs
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(
                search))
            {
                query =
                    query.Where(x =>
                        x.Название.Contains(search));
            }

            dgProducts.ItemsSource =
                query.Select(x => new
                {
                    x.ИдентификаторНоменклатуры,

                    x.Название,

                    Цена =
                        x.ПлановаяСтоимость,

                    Количество =
                        x.Запасыs.Sum(z =>
                            z.Количество)
                })
                .ToList();
        }

        private void Search_TextChanged(
            object sender,
            System.Windows.Controls
            .TextChangedEventArgs e)
        {
            LoadData(tbSearch.Text);
        }

        private void Add_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (Session.CurrentRole
                != Role.Admin)
                return;

            new ProductEditWindow()
                .ShowDialog();

            LoadData();
        }

        private void Delete_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (Session.CurrentRole
                != Role.Admin)
                return;

            dynamic selected =
                dgProducts.SelectedItem;

            if (selected == null)
                return;

            int id =
                selected
                .ИдентификаторНоменклатуры;

            var product =
                _context.Номенклатураs
                .Find(id);

            if (_context.ПозицияЗаказаs
                .Any(x =>
                    x.ИдентификаторНоменклатуры
                    == id))
            {
                MessageBox.Show(
                    "Товар есть в заказах");

                return;
            }

            if (MessageBox.Show(
                "Удалить товар?",
                "Подтверждение",
                MessageBoxButton.YesNo)
                != MessageBoxResult.Yes)
                return;

            _context.Номенклатураs
                .Remove(product);

            _context.SaveChanges();

            LoadData();
        }

        private void Admin_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (Session.CurrentRole
                != Role.Admin)
                return;

            new AdminWindow().ShowDialog();
        }

        private void Logout_Click(
            object sender,
            RoutedEventArgs e)
        {
            Session.CurrentUser = null;

            new LoginWindow().Show();

            Close();
        }
    }
}