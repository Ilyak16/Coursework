using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Плантация
{
    public int ИдентификаторПлантации { get; set; }

    public string Название { get; set; } = null!;

    public string? Адрес { get; set; }

    public decimal? Площадь { get; set; }

    public string? КонтактныеДанные { get; set; }

    public virtual ICollection<Бригада> Бригадаs { get; set; } = new List<Бригада>();

    public virtual ICollection<Поле> Полеs { get; set; } = new List<Поле>();
}
