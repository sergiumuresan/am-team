using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class MatchConfiguration : EntityTypeConfiguration<Match>
    {
        public MatchConfiguration()
        {
            Property(m => m.MatchId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasRequired(m => m.Competition)
                .WithMany(c => c.Matches)
                .HasForeignKey(m => m.CompetitionId);

            HasRequired(m => m.FirstTeam)
                .WithMany(c => c.Matches)
                .HasForeignKey(m => m.FirstTeamId);
        }
    }
}
