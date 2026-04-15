using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class КачествоКонтроля
{
    public int ИдентификаторКонтроля { get; set; }

    public int? ИдентификаторПартииТкани { get; set; }

    public DateTime? ДатаПроверки { get; set; }

    public string? ФиоИнспектора { get; set; }

    public string? Результат { get; set; }

    public string? Комментарии { get; set; }

    public virtual ПартияТкани? ИдентификаторПартииТканиNavigation { get; set; }
}
