using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ТипФабрики
{
    public int ИдентификаторТипа { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Фабрика> Фабрикаs { get; set; } = new List<Фабрика>();
}
