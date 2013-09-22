using PostIt.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PostIt.WebUI.Infrastructure.Auth
{
    public class UserProvider:IPrincipal
    {
        private UserIdentity UserIdentity { get; set; }

        public IIdentity Identity
        {
            get { return UserIdentity; }
        }

        public bool IsInRole(string role)
        {
            if (UserIdentity.User==null)
            {
                return false;
            }
            return UserIdentity.User.InRoles(role);
        }

        public UserProvider(string login, IUserRepository repository)
        {
            UserIdentity = new UserIdentity();
            UserIdentity.Init(login, repository);
        }

        public override string ToString()
        {
            return UserIdentity.Name;
        }
    }
}