using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestowaApkaAndea.Models;

namespace TestowaApkaAndea.Extensions
{
    public static class UserExtensions
    {
        public static void Map(this User dbUser, User user)
        {
            dbUser.RoleId = user.RoleId;
        }
    }
}
