using System;
using AutoMapper;
using PostIt.WebUI.Abstract;
using PostIt.Domain.Entities;
using PostIt.WebUI.Models.ViewModels;

namespace PostIt.WebUI.Infrastructure.AutoMapper
{
    public class AutoMapper : IAutoMapper
    {
        public AutoMapper()
        {
            Mapper.CreateMap<User, UserView>();
            Mapper.CreateMap<UserView, User>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

    }
}