using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestowaApkaAndea.Extensions;
using TestowaApkaAndea.Models;

namespace TestowaApkaAndea.Repository
{
    public class AppRepository : IRepository
    {
        private readonly AppDBContext appDBContext;

        public AppRepository(AppDBContext appDBContext) 
        {
            this.appDBContext = appDBContext;
        }

        public Role GetRole(int id)
        {
            var role = appDBContext.Roles.Select(r => r).Where(r => r.Id == id).FirstOrDefault();
            return role;
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = appDBContext.Roles.Select(r => r).ToList();
            return roles;
        }

        public User GetUser(int id)
        {
            var user = appDBContext.Users.Select(u => u).Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Role = GetRoleForUser(user);
            }
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = appDBContext.Users.Select(u => u);
            foreach(var user in users)
            {
                user.Role = GetRoleForUser(user);
            }
            return users;
        }

        public void UpdateUser(User dbUser, User user)
        {
            dbUser.Map(user);
            appDBContext.Users.Update(dbUser);
            appDBContext.SaveChanges();
        }

        private Role GetRoleForUser(User user)
        {
            var role = appDBContext.Roles.Select(r => r).Where(r => r.Id == user.RoleId).FirstOrDefault();
            return role;
        }

    }
}
