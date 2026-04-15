using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ТипРабот
{
    public int ИдентификаторТипаРабот { get; set; }

    public string Название { get; set; } = null!;

    public string? Описание { get; set; }

    public virtual ICollection<ПланРабот> ПланРаботs { get; set; } = new List<ПланРабот>();
}
