using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Запасы
{
    public int ИдентификаторЗапасов { get; set; }

    public int? ИдентификаторСклада { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public int? ИдентификаторПартииТкани { get; set; }

    public decimal? Количество { get; set; }

    public virtual ICollection<ДвижениеЗапасов> ДвижениеЗапасовs { get; set; } = new List<ДвижениеЗапасов>();

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }

    public virtual ПартияТкани? ИдентификаторПартииТканиNavigation { get; set; }

    public virtual Склад? ИдентификаторСкладаNavigation { get; set; }
}
