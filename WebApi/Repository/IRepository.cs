using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestowaApkaAndea.Models;

namespace TestowaApkaAndea.Repository
{
    public interface IRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User dbUser, User user);
        IEnumerable<Role> GetRoles();
        Role GetRole(int id);
    }
}
