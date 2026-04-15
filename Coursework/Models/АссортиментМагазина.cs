using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class АссортиментМагазина
{
    public int ИдентификаторАссортимента { get; set; }

    public int? ИдентификаторМагазина { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public decimal? МинимальноеКоличество { get; set; }

    public decimal? МаксимальноеКоличество { get; set; }

    public virtual Магазин? ИдентификаторМагазинаNavigation { get; set; }

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }
}
