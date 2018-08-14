using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Configuration
{
    class TeamEntityConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamEntityConfiguration()
        {
            this.ToTable("Teams");

            this.HasKey(t => t.TeamId);

            this.Property(t => t.Name).HasMaxLength(50).IsRequired();
            this.Property(t => t.City).HasMaxLength(50).IsRequired();
            this.Property(t => t.Coach).HasMaxLength(50).IsRequired();

            this.HasMany<Player>(t => t.Players)
                .WithRequired(t => t.Team);
            
        }
    }
}
