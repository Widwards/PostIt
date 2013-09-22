using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostIt.WebUI.Abstract
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}