using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Ресурс
{
    public int ИдентификаторРесурса { get; set; }

    public string? ТипРесурса { get; set; }

    public string Название { get; set; } = null!;

    public string? СистемаСчисления { get; set; }

    public virtual ICollection<ИспользованиеРесурсов> ИспользованиеРесурсовs { get; set; } = new List<ИспользованиеРесурсов>();
}
