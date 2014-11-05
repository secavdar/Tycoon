using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    using Model;
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {

        }

        public DbSet<LoginHistory> LoginHistories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}