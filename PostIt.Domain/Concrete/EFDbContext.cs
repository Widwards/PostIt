using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIt.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Note>      Notes { get; set; }
        public DbSet<User>      Users { get; set; }
        public DbSet<Page>      Pages { get; set; }
        public DbSet<Role>      Roles { get; set; }
    }
}
