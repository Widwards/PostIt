using PostIt.WebUI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostIt.Domain.Entities;
using PostIt.Domain.Abstract;
using System.Web.Security;
using System.Security.Principal;
using Ninject;

namespace PostIt.WebUI.Infrastructure.Auth
{
    public class Authentication : IAuthentication
    {
        private const string CookieName = "_AUTH";

        [Inject]
        public IUserRepository Reposotory { get; set; }
        public HttpContext HttpContext { get; set; }

        public User Login(string login, string password, bool isPersistent)
        {
            User retUser = Reposotory.Login(login, password);
            if (retUser != null)
            {
                CreateCookie(login, isPersistent);
            }
            return retUser;
        }

        private void CreateCookie(string login, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                login,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            var encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(CookieName)
                {
                    Value = encTicket,
                    Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
                };
            HttpContext.Response.SetCookie(authCookie);
        }

        public User Login(string login)
        {//TODO: return user by login [DONE]
            User retUser = Reposotory.Users.FirstOrDefault(x => string.Compare(x.Login, login, true) == 0);
            if (retUser!=null)
            {
                CreateCookie(login);
            }
            return retUser;
        }

        public void Logout()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal _currentUser;



        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser==null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies[CookieName];
                        if (authCookie!=null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            if (ticket != null) _currentUser = new UserProvider(ticket.Name, Reposotory);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception)
                    {//TODO: implement exception "Failed Authentication"
   
                        _currentUser = new UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }
    }
}