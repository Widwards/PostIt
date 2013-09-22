using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PostIt.Domain.Entities
{
    public class User
    {
        public int                          UserId { get; set; }
        [Required]
        public string                       Login { get; set; }
        [Required]
        public string                       Password { get; set; }
        public DateTime?                    AddedDate { get; set; }
        public string                       ActivateLink { get; set; }
        public string                       AvatarPath { get; set; }
        public string                       Email { get; set; }
        [Required]
        public virtual ICollection<Role>    Roles { get; set; }
        public string                       Name { get; set; }
        
        public bool InRoles(string roles)
        {//TODO:*** roles [DONE]
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }
            var rolesArray = roles.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = Roles.Any(p => string.Compare(p.Name, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
