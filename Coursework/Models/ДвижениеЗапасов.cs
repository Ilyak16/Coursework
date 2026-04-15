using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ДвижениеЗапасов
{
    public int ИдентификаторДвиженияЗапасов { get; set; }

    public int? ИдентификаторЗапасов { get; set; }

    public string? ТипДвижения { get; set; }

    public decimal? Количество { get; set; }

    public DateTime? ДатаПеремещения { get; set; }

    public virtual Запасы? ИдентификаторЗапасовNavigation { get; set; }
}
