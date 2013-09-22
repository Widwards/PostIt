using Ninject;
using PostIt.Domain.Entities;
using PostIt.WebUI.Abstract;
using PostIt.WebUI.Infrastructure.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostIt.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [Inject]
        public IAuthentication Authentication { get; set; }

        public User CurrentUser
        {
            get { return ((IUserProvider) Authentication.CurrentUser.Identity).User; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

    }
}
