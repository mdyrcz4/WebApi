using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestowaApkaAndea.Extensions;
using TestowaApkaAndea.Models;

namespace TestowaApkaAndea.Repository
{
    public class MockRepository : IRepository
    {
        private List<Role> roles;
        private List<User> users;

        public MockRepository()
        {
            roles = new List<Role>()
            {
                new Role{Id = 1, Name = "Admin"},
                new Role{Id = 2, Name = "Moderator"},
                new Role{Id = 3, Name = "User"}
            };

            users = new List<User>()
            {
                new User{Id = 1, FirstName = "Marcin", LastName = "Dyrcz", RoleId = 1},
                new User{Id = 2, FirstName = "Jan", LastName = "Kowalski", RoleId = 2},
                new User{Id = 3, FirstName = "Damian", LastName = "Nowak", RoleId = 3},
                new User{Id = 4, FirstName = "Janusz", LastName = "Nosacz", RoleId = 3}
            };
        }

        public Role GetRole(int id)
        {
            var role = roles.Select(r => r).Where(r => r.Id == id).FirstOrDefault();
            return role;
        }

        public IEnumerable<Role> GetRoles()
        {
            return roles;
        }

        public User GetUser(int id)
        {
            var user = users.Select(u => u).Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public void UpdateUser(User dbUser, User user)
        {
            var _u = users.Select(u => u).Where(u => u.Id == dbUser.Id).FirstOrDefault();
            _u.RoleId = user.RoleId;
        }
    }
}
