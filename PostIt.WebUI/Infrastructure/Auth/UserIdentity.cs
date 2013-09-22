using PostIt.Domain.Abstract;
using PostIt.Domain.Entities;
using PostIt.WebUI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PostIt.WebUI.Infrastructure.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {


        public User User { get; set; }

        public string AuthenticationType
        {
            get { return typeof(User).ToString(); }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Login;
                }
                return "Anonymous";
            }
        }

        public void Init(string login, IUserRepository repository)
        {
            if (!string.IsNullOrEmpty(login))
            {
                User = repository.GetUser(login);
            }
        }
    }
}