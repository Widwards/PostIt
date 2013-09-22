using System;
namespace PostIt.WebUI.Abstract
{
    public interface IAutoMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
