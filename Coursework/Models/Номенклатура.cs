using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Номенклатура
{
    public int ИдентификаторНоменклатуры { get; set; }

    public int? ИдентификаторКатегорииТоваров { get; set; }

    public string Название { get; set; } = null!;

    public string? Артикул { get; set; }

    public string? Единицы { get; set; }

    public decimal? ПлановаяСтоимость { get; set; }

    public virtual ICollection<АссортиментМагазина> АссортиментМагазинаs { get; set; } = new List<АссортиментМагазина>();

    public virtual ICollection<Запасы> Запасыs { get; set; } = new List<Запасы>();

    public virtual КатегорияТоваров? ИдентификаторКатегорииТоваровNavigation { get; set; }

    public virtual ICollection<ПартияПряжи> ПартияПряжиs { get; set; } = new List<ПартияПряжи>();

    public virtual ICollection<ПартияТкани> ПартияТканиs { get; set; } = new List<ПартияТкани>();

    public virtual ICollection<ПозицияЗаказа> ПозицияЗаказаs { get; set; } = new List<ПозицияЗаказа>();

    public virtual ICollection<ПозицияЧека> ПозицияЧекаs { get; set; } = new List<ПозицияЧека>();

    public virtual ICollection<Поставка> Поставкаs { get; set; } = new List<Поставка>();

    public virtual ICollection<Ценообразование> Ценообразованиеs { get; set; } = new List<Ценообразование>();
}
