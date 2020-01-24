using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings
{
    public class JumpingsContext : DbContext
    {
        public DbSet<Jumper> Jumper { get; set; }
        public JumpingsContext()
            : base("SkiJumpers")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JumperConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
