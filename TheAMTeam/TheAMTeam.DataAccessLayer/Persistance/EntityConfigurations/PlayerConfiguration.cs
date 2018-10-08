using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class PlayerConfiguration : EntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
        {
            Property(p => p.PlayerId)
                //I think this line is not good because I use DataAnnotation but I'm not sure
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Name)
                .HasMaxLength(20);

            Property(p => p.NameAlias)
                .HasMaxLength(20);

            //HasRequired(p => p.Team)
            //    .WithMany(m => m.Players)
            //    .HasForeignKey(p => p.PlayerId);
        }
    }
}
