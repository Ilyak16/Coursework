using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ИспользованиеРесурсов
{
    public int ИдентификаторИспользования { get; set; }

    public int? ИдентификаторРесурса { get; set; }

    public int? ИдентификаторПланаРабот { get; set; }

    public decimal? Количество { get; set; }

    public DateTime? Дата { get; set; }

    public virtual ПланРабот? ИдентификаторПланаРаботNavigation { get; set; }

    public virtual Ресурс? ИдентификаторРесурсаNavigation { get; set; }
}
