using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class EquipmentTypeEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private ТипТехники _entity;

        public EquipmentTypeEditWindow(ТипТехники equipmentType = null)
        {
            InitializeComponent();

            if (equipmentType == null)
            {
                _entity = new ТипТехники();
                Title = "Добавление типа техники";
            }
            else
            {
                _entity = equipmentType;
                Title = "Редактирование типа техники";
                tbName.Text = _entity.Название;
                tbCategory.Text = _entity.Категория;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            try
            {
                _entity.Название = tbName.Text;
                _entity.Категория = tbCategory.Text;

                if (_entity.ИдентификаторТипаТехники == 0)
                    _context.ТипТехникиs.Add(_entity);

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