using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class NationalityConfiguration : EntityTypeConfiguration<Nationality>
    {
        public NationalityConfiguration()
        {
            Property(n => n.NationalityId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(n => n.Name)
                .HasMaxLength(20);

        }
    }
}
