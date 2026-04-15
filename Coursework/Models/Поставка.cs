using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Поставка
{
    public int ИдентификаторПоставки { get; set; }

    public int? ИдентификаторМагазина { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public decimal? ЗапланированноеКоличествоПоставки { get; set; }

    public decimal? ДействительноеКоличествоПоставки { get; set; }

    public DateTime? Дата { get; set; }

    public virtual Магазин? ИдентификаторМагазинаNavigation { get; set; }

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }
}
