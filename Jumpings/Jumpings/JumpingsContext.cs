using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumpings.Repos;
using NLog;

namespace Jumpings
{
    public class JumpingsContext : DbContext
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

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

        public void CommitTransaction(DbContextTransaction transaction)
        {
            try
            {
                SaveChanges();
                transaction.Commit();
            }
            catch
            {
                logger.Info("Zapisanie zmian nie powiodło się");
                transaction.Rollback();
            }

        }
    }
}
