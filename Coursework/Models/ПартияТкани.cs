using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ПартияТкани
{
    public int ИдентификаторТкани { get; set; }

    public int? ИдентификаторПартииПряжи { get; set; }

    public int? ИдентификаторФабрики { get; set; }

    public string? Тип { get; set; }

    public string? Цвет { get; set; }

    public decimal? Вес { get; set; }

    public string? Статус { get; set; }

    public decimal? Плотность { get; set; }

    public int? ИдентификаторНоменклатуры { get; set; }

    public virtual ICollection<Запасы> Запасыs { get; set; } = new List<Запасы>();

    public virtual Номенклатура? ИдентификаторНоменклатурыNavigation { get; set; }

    public virtual ПартияПряжи? ИдентификаторПартииПряжиNavigation { get; set; }

    public virtual Фабрика? ИдентификаторФабрикиNavigation { get; set; }

    public virtual ICollection<КачествоКонтроля> КачествоКонтроляs { get; set; } = new List<КачествоКонтроля>();
}
