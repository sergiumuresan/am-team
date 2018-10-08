using System.Data.Entity.ModelConfiguration;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class CompetitionTypeConfiguration : EntityTypeConfiguration<CompetitionType>
    {
        public CompetitionTypeConfiguration()
        {
            HasKey(ct => ct.CompetionId);
        }
    }
}
