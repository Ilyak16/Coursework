using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ПланРабот
{
    public int ИдентификаторПлана { get; set; }

    public int? ИдентификаторТипаРабот { get; set; }

    public int? ИдентификаторПоля { get; set; }

    public DateTime? ЗапланированныйСтарт { get; set; }

    public DateTime? ЗапланированныйКонец { get; set; }

    public string? Статус { get; set; }

    public virtual Поле? ИдентификаторПоляNavigation { get; set; }

    public virtual ТипРабот? ИдентификаторТипаРаботNavigation { get; set; }

    public virtual ICollection<ИспользованиеРесурсов> ИспользованиеРесурсовs { get; set; } = new List<ИспользованиеРесурсов>();
}
