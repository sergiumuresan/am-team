using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Configuration
{
    class CompetitionEntityConfiguration: EntityTypeConfiguration<CompetitionType>
    {
        public CompetitionEntityConfiguration()
        {
            this.ToTable("Competitions");

            this.HasKey(c => c.CompetionId);

            this.Property(c => c.Name).HasMaxLength(50).IsRequired();

            this.HasMany<Match>(c=>c.Matches)
                .WithRequired(x=>x.Competition)
                .HasForeignKey(m=>m.CompetitionId)
                .WillCascadeOnDelete();
        }
    }
}
