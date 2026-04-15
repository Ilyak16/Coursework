using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Урожай
{
    public int ИдентификаторУрожая { get; set; }

    public int? ИдентификаторПоля { get; set; }

    public DateTime? ДатаЖатвы { get; set; }

    public decimal? ВесСырца { get; set; }

    public string? КачествоСырца { get; set; }

    public virtual Поле? ИдентификаторПоляNavigation { get; set; }

    public virtual ICollection<Кипа> Кипаs { get; set; } = new List<Кипа>();

    public virtual ICollection<Перевозка> Перевозкаs { get; set; } = new List<Перевозка>();
}
