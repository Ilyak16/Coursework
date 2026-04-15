using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ПозицияЧека
{
    public int ИдентификаторПозицииЧека { get; set; }

    public int? ИдентификаторПродажи { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public decimal? Количество { get; set; }

    public decimal? Цена { get; set; }

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }

    public virtual Продажа? ИдентификаторПродажиNavigation { get; set; }
}
