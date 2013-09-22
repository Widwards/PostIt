using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PostIt.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }


    }
}
