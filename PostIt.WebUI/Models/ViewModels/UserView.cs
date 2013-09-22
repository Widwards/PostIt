using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostIt.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI;

namespace PostIt.WebUI.Models.ViewModels
{
    public class UserView
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter correct Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public List<Role> RolesList { get; set; }
        //[Required(ErrorMessage = "Selected roles")]
        
        public IEnumerable<Role> Roles { get; set; }


    }
}