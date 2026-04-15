using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ТипТехники
{
    public int ИдентификаторТипаТехники { get; set; }

    public string Название { get; set; } = null!;

    public string? Категория { get; set; }

    public virtual ICollection<Техника> Техникаs { get; set; } = new List<Техника>();
}
