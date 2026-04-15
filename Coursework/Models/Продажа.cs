using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Продажа
{
    public int ИдентификаторПродажи { get; set; }

    public int? ИдентификаторМагазина { get; set; }

    public DateTime? Дата { get; set; }

    public decimal? ОбщаяСтоимость { get; set; }

    public virtual Магазин? ИдентификаторМагазинаNavigation { get; set; }

    public virtual ICollection<ПозицияЧека> ПозицияЧекаs { get; set; } = new List<ПозицияЧека>();
}
