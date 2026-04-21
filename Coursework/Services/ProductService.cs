using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coursework.Models;

namespace Coursework.Services
{
    public class ProductService
    {
        private KupriyanovIlya2307a1HlopokContext _context = new();

        public object GetProducts()
        {
            return _context.Номенклатураs
                .Select(x => new
                {
                    x.ИдентификаторНоменклатуры,
                    x.Название,
                    Цена = x.ПлановаяСтоимость,
                    Категория = x.ИдентификаторКатегорииТоваровNavigation.Название,
                    Количество = x.Запасыs.Sum(z => z.Количество)
                }).ToList();
        }
    }
}
