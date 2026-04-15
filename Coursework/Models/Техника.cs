using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Техника
{
    public int ИдентификаторТехники { get; set; }

    public int? ИдентификаторТипаТехники { get; set; }

    public string? Модель { get; set; }

    public string? Серия { get; set; }

    public DateOnly? СрокЭксплуатации { get; set; }

    public string? Статус { get; set; }

    public virtual ICollection<ЗакреплениеТехники> ЗакреплениеТехникиs { get; set; } = new List<ЗакреплениеТехники>();

    public virtual ТипТехники? ИдентификаторТипаТехникиNavigation { get; set; }
}
