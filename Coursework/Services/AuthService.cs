using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coursework.Models;

namespace Coursework.Services
{
    public class AuthService
    {
        private KupriyanovIlya2307a1HlopokContext _context = new();

        public Пользователь Login(string login, string password)
        {
            return _context.Пользовательs
                .FirstOrDefault(x => x.Логин == login && x.Пароль == password);
        }
    }
}
