using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Перевозка
{
    public int ИдентификаторПеревозки { get; set; }

    public int? ИдентификаторУрожая { get; set; }

    public decimal? ВесУрожая { get; set; }

    public DateTime? Дата { get; set; }

    public int? ИдентификаторФабрики { get; set; }

    public virtual Урожай? ИдентификаторУрожаяNavigation { get; set; }

    public virtual Фабрика? ИдентификаторФабрикиNavigation { get; set; }
}
