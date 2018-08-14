using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Configuration
{
    class MatchEntityConfiguration: EntityTypeConfiguration<Match>
    {
        public MatchEntityConfiguration()
        {
            this.ToTable("Matches");

            this.HasKey(m=>m.MatchId);

            this.Property(m => m.FirstTeamScore)
                .IsRequired();

            this.Property(m => m.SecondTeamScore)
                .IsRequired();

            this.Property(m => m.MatchDate)
                .IsOptional();

            this.HasRequired(m => m.Competition)
                .WithMany()
                .HasForeignKey(m => m.CompetitionId)
                .WillCascadeOnDelete(true);

            this.HasRequired(m => m.First)
                .WithMany()
                .HasForeignKey(m => m.FirstId)
                .WillCascadeOnDelete(false);

            this.HasRequired(m => m.Second)
                .WithMany()
                .HasForeignKey(m => m.SecondId)
                .WillCascadeOnDelete(false);
        }
    }
}
