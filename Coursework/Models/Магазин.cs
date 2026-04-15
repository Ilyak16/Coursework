using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Магазин
{
    public int ИдентификаторМагазина { get; set; }

    public int? ИдентификаторСклада { get; set; }

    public string Название { get; set; } = null!;

    public string? Адрес { get; set; }

    public virtual ICollection<АссортиментМагазина> АссортиментМагазинаs { get; set; } = new List<АссортиментМагазина>();

    public virtual Склад? ИдентификаторСкладаNavigation { get; set; }

    public virtual ICollection<Поставка> Поставкаs { get; set; } = new List<Поставка>();

    public virtual ICollection<Продажа> Продажаs { get; set; } = new List<Продажа>();
}
