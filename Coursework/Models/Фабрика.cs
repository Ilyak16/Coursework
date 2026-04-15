using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Фабрика
{
    public int ИдентификаторФабрики { get; set; }

    public int? ИдентификаторТипаФабрики { get; set; }

    public string Название { get; set; } = null!;

    public string? Адрес { get; set; }

    public decimal? ВместимостьСклада { get; set; }

    public virtual ICollection<ЗакреплениеТехники> ЗакреплениеТехникиs { get; set; } = new List<ЗакреплениеТехники>();

    public virtual ТипФабрики? ИдентификаторТипаФабрикиNavigation { get; set; }

    public virtual ICollection<Кипа> Кипаs { get; set; } = new List<Кипа>();

    public virtual ICollection<ПартияПряжи> ПартияПряжиs { get; set; } = new List<ПартияПряжи>();

    public virtual ICollection<ПартияТкани> ПартияТканиs { get; set; } = new List<ПартияТкани>();

    public virtual ICollection<Перевозка> Перевозкаs { get; set; } = new List<Перевозка>();
}
