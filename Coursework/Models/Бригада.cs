using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Бригада
{
    public int ИдентификаторБригады { get; set; }

    public string? ТипБригады { get; set; }

    public int? ИдентификаторБригадира { get; set; }

    public int? ИдентификаторПлантации { get; set; }

    public virtual Рабочий? ИдентификаторБригадираNavigation { get; set; }

    public virtual Плантация? ИдентификаторПлантацииNavigation { get; set; }

    public virtual ICollection<Рабочий> Рабочийs { get; set; } = new List<Рабочий>();
}
