using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Кипа
{
    public int ИдентификаторКипы { get; set; }

    public int? ИдентификаторУрожая { get; set; }

    public int? ИдентификаторФабрики { get; set; }

    public string? Качество { get; set; }

    public decimal? Вес { get; set; }

    public DateTime? ДатаПроизводства { get; set; }

    public virtual Урожай? ИдентификаторУрожаяNavigation { get; set; }

    public virtual Фабрика? ИдентификаторФабрикиNavigation { get; set; }

    public virtual ICollection<ПартияПряжи> ПартияПряжиs { get; set; } = new List<ПартияПряжи>();
}
