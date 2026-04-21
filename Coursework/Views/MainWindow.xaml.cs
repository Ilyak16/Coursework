using Coursework.Core;
using Coursework.Models;
using Coursework.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework.Views
{
    public partial class MainWindow : Window
    {
        private KupriyanovIlya2307a1HlopokContext _context = new();

        public MainWindow()
        {
            InitializeComponent();

            tbUser.Text = Session.CurrentUser?.ФИО ?? "Гость";

            SetupPermissions();
            LoadData();
        }

        private void SetupPermissions()
        {
            if (Session.CurrentRole != Role.Admin)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadData()
        {
            dgProducts.ItemsSource = _context.Номенклатураs
                .Select(x => new
                {
                    x.ИдентификаторНоменклатуры,
                    x.Название,
                    Цена = x.ПлановаяСтоимость,
                    Количество = x.Запасыs.Sum(z => z.Количество)
                }).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Session.CurrentRole != Role.Admin)
                return;

            new ProductEditWindow().ShowDialog();
            LoadData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Session.CurrentRole != Role.Admin)
                return;

            dynamic selected = dgProducts.SelectedItem;
            if (selected == null) return;

            int id = selected.ИдентификаторНоменклатуры;

            var product = _context.Номенклатураs.Find(id);

            if (_context.ПозицияЗаказаs.Any(x => x.ИдентификаторНоменклатуры == id))
            {
                MessageBox.Show("Есть в заказе");
                return;
            }

            _context.Номенклатураs.Remove(product);
            _context.SaveChanges();

            LoadData();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;
            new LoginWindow().Show();
            this.Close();
        }
    }
}