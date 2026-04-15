using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class КатегорияТоваров
{
    public int ИдентификаторКатегорииТоваров { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Номенклатура> Номенклатураs { get; set; } = new List<Номенклатура>();
}
