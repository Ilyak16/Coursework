using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Models
{
    [Table("Пользователь")]
    public class Пользователь
    {
        public int Id { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string ФИО { get; set; }
        public string Роль { get; set; }
    }
}
