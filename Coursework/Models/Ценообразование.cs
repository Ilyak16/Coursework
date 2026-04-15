using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Ценообразование
{
    public int ИдентификаторЦенообразования { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public decimal? БазоваяЦена { get; set; }

    public decimal? СкидкаДляПредпринимателей { get; set; }

    public decimal? СкидкаДляЛояльных { get; set; }

    public DateTime? ДействительнаОт { get; set; }

    public DateTime? ДействительнаДо { get; set; }

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }
}
