using Coursework.Models;
using System.Windows;

namespace Coursework.Views
{
    public partial class WorkTypeEditWindow : Window
    {
        private readonly KupriyanovIlya2307a1HlopokContext _context = new();
        private ТипРабот _entity;

        public WorkTypeEditWindow(ТипРабот workType = null)
        {
            InitializeComponent();

            if (workType == null)
            {
                _entity = new ТипРабот();
                Title = "Добавление типа работ";
            }
            else
            {
                _entity = workType;
                Title = "Редактирование типа работ";
                tbName.Text = _entity.Название;
                tbDescription.Text = _entity.Описание;
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
                _entity.Описание = tbDescription.Text;

                if (_entity.ИдентификаторТипаРабот == 0)
                    _context.ТипРаботs.Add(_entity);

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