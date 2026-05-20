using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class ResourceEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private Ресурс _entity;

        public ResourceEditWindow(Ресурс resource = null)
        {
            InitializeComponent();

            if (resource == null)
            {
                _entity = new Ресурс();
                Title = "Добавление ресурса";
            }
            else
            {
                _entity = resource;
                Title = "Редактирование ресурса";
                tbName.Text = _entity.Название;
                tbType.Text = _entity.ТипРесурса;
                tbUnit.Text = _entity.СистемаСчисления;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите название ресурса");
                return;
            }

            try
            {
                _entity.Название = tbName.Text;
                _entity.ТипРесурса = tbType.Text;
                _entity.СистемаСчисления = tbUnit.Text;

                if (_entity.ИдентификаторРесурса == 0)
                    _context.Ресурсs.Add(_entity);

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