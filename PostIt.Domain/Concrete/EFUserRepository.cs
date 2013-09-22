using PostIt.Domain.Abstract;
using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIt.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }
        public IQueryable<Role> Roles {
            get { return context.Roles; }
        }
        public bool DeleteUser(User user)
        {//TODO:** Delete user [DONE]
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
        public bool EditPassword(int userId, string newPassword)
        {//TODO:** Edit password [DONE]
            User userEdit = context.Users.FirstOrDefault(x => x.UserId == userId);
            if (userEdit==null)
            {
                return false;    
            }
            userEdit.Password = newPassword;
            context.SaveChanges();
            return true;

        }

        public bool SaveUser(User user)
        {
            user.AddedDate = DateTime.Now;
            user.ActivateLink = Guid.NewGuid().ToString("N");
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public User Login(string login, string password)
        {//TODO:*** User login [DONE]
            return
                context.Users.FirstOrDefault(
                    x => String.CompareOrdinal(x.Login, login) == 0 && x.Password == password);
        }


        public bool AddRole(Role newRole)
        {
            context.Roles.Add(newRole);
            context.SaveChanges();
            return true;
        }

        public User GetUser(string login)
        {
            return context.Users.FirstOrDefault(x => String.Compare(x.Login, login, StringComparison.OrdinalIgnoreCase) == 0);
        }
    }
}
