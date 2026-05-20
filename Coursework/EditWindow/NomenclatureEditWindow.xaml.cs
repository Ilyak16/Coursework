using Coursework.Models;
using System;
using System.Linq;
using System.Windows;

namespace Coursework.Views
{
    public partial class NomenclatureEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private Номенклатура _entity; // Текущая сущность

        // Конструктор принимает товар. Если null — значит создаем новый
        public NomenclatureEditWindow(Номенклатура product = null)
        {
            InitializeComponent();

            // Загружаем список категорий в ComboBox
            cbCategory.ItemsSource = _context.КатегорияТоваровs.ToList();

            if (product == null)
            {
                // Режим создания
                _entity = new Номенклатура();
                Title = "Добавление товара";
            }
            else
            {
                // Режим редактирования
                _entity = product;
                Title = "Редактирование товара";

                // Заполняем поля данными
                tbName.Text = _entity.Название;
                tbPrice.Text = _entity.ПлановаяСтоимость.ToString();

                // Выбираем нужную категорию в ComboBox
                var cat = _context.КатегорияТоваровs.Find(_entity.ИдентификаторКатегорииТоваров);
                if (cat != null) cbCategory.SelectedItem = cat;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Записываем данные из полей в объект
                _entity.Название = tbName.Text;

                if (decimal.TryParse(tbPrice.Text, out decimal price))
                    _entity.ПлановаяСтоимость = price;
                else
                {
                    MessageBox.Show("Некорректная цена");
                    return;
                }

                var selectedCat = cbCategory.SelectedItem as КатегорияТоваров;
                if (selectedCat != null)
                    _entity.ИдентификаторКатегорииТоваров = selectedCat.ИдентификаторКатегорииТоваров;

                // 2. Сохраняем
                // Если это новый товар, EF сам поймет, что его надо добавить (Add)
                // Если существующий — обновит (Update)
                _context.SaveChanges();

                MessageBox.Show("Сохранено успешно!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}