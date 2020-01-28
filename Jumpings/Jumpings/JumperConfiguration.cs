using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Jumpings
{
    public class JumperConfiguration : EntityTypeConfiguration<Jumper>
    {
        public JumperConfiguration()
        {
            HasKey(j => j.ID);

            Property(j => j.ID)
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .IsRequired();

            Property(j => j.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();

            Property(j => j.LastName)
                    .HasMaxLength(100)
                    .IsRequired();

            Property(j => j.Country)
                    .HasMaxLength(100)
                    .IsRequired();
        }
    }
}
