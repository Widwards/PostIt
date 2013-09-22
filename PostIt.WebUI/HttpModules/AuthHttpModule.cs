using Ninject;
using PostIt.WebUI.Abstract;
using PostIt.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostIt.WebUI.HttpModules
{
    /// <summary>
    /// Http модуль авторизации.
    /// </summary>
    public class AuthHttpModule:IHttpModule
    {
        [Inject]
        private IAuthentication Authentication { get; set; }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += this.Authenticate;
        }
        

        public void Authenticate(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication) source;
            HttpContext context = app.Context;

            //TODO: very bad
            Authentication.HttpContext = context;

            context.User = Authentication.CurrentUser;

        }
    }
}