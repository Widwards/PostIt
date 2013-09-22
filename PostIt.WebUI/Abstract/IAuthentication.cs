using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PostIt.WebUI.Abstract
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        User Login(string login, string password, bool isPersistent);
        User Login(string login);
        void Logout();
        IPrincipal CurrentUser { get; }
    }
}
