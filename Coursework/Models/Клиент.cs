using System;
using System.Collections.Generic;

namespace Coursework.Models;

public partial class Клиент
{
    public int ИдентификаторКлиента { get; set; }

    public string? ТипКлиента { get; set; }

    public string? ФиоИлиНазваниеКомпании { get; set; }

    public string? КонтактнаяИнформация { get; set; }

    public string? УровеньЛояльности { get; set; }

    public virtual ICollection<Заказ> Заказs { get; set; } = new List<Заказ>();
}
