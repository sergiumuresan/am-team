using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            Property(t => t.TeamId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasMaxLength(15);

            Property(t => t.City)
                .HasMaxLength(15);

            Property(t => t.Coach)
                .HasMaxLength(15);


        }
    }
}
