using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Рабочий
{
    public int ИдентификаторРабочего { get; set; }

    public int? ИдентификаторБригады { get; set; }

    public string Фио { get; set; } = null!;

    public string? Должность { get; set; }

    public string? НомерТелефона { get; set; }

    public virtual ICollection<Бригада> Бригадаs { get; set; } = new List<Бригада>();

    public virtual Бригада? ИдентификаторБригадыNavigation { get; set; }
}
