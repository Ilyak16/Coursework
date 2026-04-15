using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Поле
{
    public int ИдентификаторПоля { get; set; }

    public int? ИдентификаторПлантации { get; set; }

    public decimal? Площадь { get; set; }

    public string? ТипПочвы { get; set; }

    public string? Статус { get; set; }

    public virtual ICollection<ЗакреплениеТехники> ЗакреплениеТехникиs { get; set; } = new List<ЗакреплениеТехники>();

    public virtual Плантация? ИдентификаторПлантацииNavigation { get; set; }

    public virtual ICollection<ПланРабот> ПланРаботs { get; set; } = new List<ПланРабот>();

    public virtual ICollection<Урожай> Урожайs { get; set; } = new List<Урожай>();
}
