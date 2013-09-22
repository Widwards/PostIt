using PostIt.Domain.Concrete;
using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIt.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Role> Roles { get; }
        User Login(string login, string password);
        bool DeleteUser(User user);
        bool EditPassword(int userId, string newPassword);
        User GetUser(string login);
        bool AddRole(Role newRole);
        bool SaveUser(User user);
    }
}
