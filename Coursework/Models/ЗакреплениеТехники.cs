using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class ЗакреплениеТехники
{
    public int ИдентификаторЗакрепления { get; set; }

    public int? ИдентификаторТехники { get; set; }

    public int? ИдентификаторПоля { get; set; }

    public int? ИдентификаторФабрики { get; set; }

    public DateTime? ДатаЗакрепления { get; set; }

    public DateTime? ДатаОткрепления { get; set; }

    public virtual Поле? ИдентификаторПоляNavigation { get; set; }

    public virtual Техника? ИдентификаторТехникиNavigation { get; set; }

    public virtual Фабрика? ИдентификаторФабрикиNavigation { get; set; }
}
