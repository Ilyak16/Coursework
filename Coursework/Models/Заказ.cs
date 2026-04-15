using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Заказ
{
    public int ИдентификаторЗаказа { get; set; }

    public int? ИдентификаторКлиента { get; set; }

    public decimal? ОбщаяСтоимость { get; set; }

    public string? Статус { get; set; }

    public DateTime? Дата { get; set; }

    public virtual Клиент? ИдентификаторКлиентаNavigation { get; set; }

    public virtual ICollection<ПозицияЗаказа> ПозицияЗаказаs { get; set; } = new List<ПозицияЗаказа>();
}
