using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ПартияПряжи
{
    public int ИдентификаторПряжи { get; set; }

    public int? ИдентификаторКипы { get; set; }

    public int? ИдентификаторФабрики { get; set; }

    public string? ТипПряжи { get; set; }

    public string? Качество { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public virtual Кипа? ИдентификаторКипыNavigation { get; set; }

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }

    public virtual Фабрика? ИдентификаторФабрикиNavigation { get; set; }

    public virtual ICollection<ПартияТкани> ПартияТканиs { get; set; } = new List<ПартияТкани>();
}
