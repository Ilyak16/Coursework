using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class CategoryEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private КатегорияТоваров _entity;

        public CategoryEditWindow(КатегорияТоваров category = null)
        {
            InitializeComponent();

            if (category == null)
            {
                _entity = new КатегорияТоваров();
                Title = "Добавление категории";
            }
            else
            {
                _entity = category;
                Title = "Редактирование категории";
                tbName.Text = _entity.Название;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите название категории");
                return;
            }

            try
            {
                _entity.Название = tbName.Text;

                if (_entity.ИдентификаторКатегорииТоваров == 0)
                    _context.КатегорияТоваровs.Add(_entity);

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