using Moq;
using Ninject;
using PostIt.Domain.Abstract;
using PostIt.Domain.Entities;
using PostIt.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostIt.WebUI.Abstract;
using PostIt.WebUI.Infrastructure.Auth;
using PostIt.WebUI.Infrastructure;


namespace PostIt.WebUI.Infrastructure
{


    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                       ? null
                       : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<INoteRepository>().To<EFNoteRepository>();
            ninjectKernel.Bind<IAuthentication>().To<Authentication>();
            ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
            ninjectKernel.Bind<IAutoMapper>().To<AutoMapper.AutoMapper>().InSingletonScope();

        }



    }
}