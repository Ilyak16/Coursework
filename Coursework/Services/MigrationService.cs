using Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Services
{
    public static class MigrationService
    {
        public static void MigratePasswords()
        {
            using
            KupriyanovIlya2307a1HlopokContext
                context = new();

            var users =
                context.Пользовательs.ToList();

            bool changed = false;

            foreach (var user in users)
            {
                if (!HashService.IsHash(
                    user.Пароль))
                {
                    user.Пароль =
                        HashService
                        .ComputeSha512(
                            user.Пароль);

                    changed = true;
                }
            }

            if (changed)
            {
                context.SaveChanges();
            }
        }
    }
}
