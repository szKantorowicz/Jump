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
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
                Logger.Info("Zapisanie zmian nie powiodło się");
                transaction.Rollback();
            }

        }
    }
}
