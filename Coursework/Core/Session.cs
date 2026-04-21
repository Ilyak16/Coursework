using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Models;
namespace Coursework.Core
{
    public static class Session
    {
        public static Пользователь CurrentUser { get; set; }

        public static Role CurrentRole
        {
            get
            {
                if (CurrentUser == null)
                    return Role.Guest;

                return CurrentUser.Роль switch
                {
                    "Администратор" => Role.Admin,
                    "Менеджер" => Role.Manager,
                    _ => Role.Client
                };
            }
        }
    }
}
