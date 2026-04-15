using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ПозицияЗаказа
{
    public int ИдентификаторПозиции { get; set; }

    public int? ИдентификаторЗаказа { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public decimal? Количество { get; set; }

    public decimal? Стоимость { get; set; }

    public decimal? Скидка { get; set; }

    public virtual Заказ? ИдентификаторЗаказаNavigation { get; set; }

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }
}
