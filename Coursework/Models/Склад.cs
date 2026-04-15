using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Склад
{
    public int ИдентификаторСклада { get; set; }

    public string Название { get; set; } = null!;

    public string? Адрес { get; set; }

    public string? ТипПродукции { get; set; }

    public virtual ICollection<Запасы> Запасыs { get; set; } = new List<Запасы>();

    public virtual ICollection<Магазин> Магазинs { get; set; } = new List<Магазин>();
}
