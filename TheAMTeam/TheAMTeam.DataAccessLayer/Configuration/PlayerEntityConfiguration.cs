using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Configuration
{
    class PlayerEntityConfiguration: EntityTypeConfiguration<Player>
    {
        public PlayerEntityConfiguration()
        {
            this.ToTable("Players");

            this.HasKey(p => p.PlayerId);

            this.Property(p => p.Name).HasMaxLength(50).IsRequired();

            this.Property(p => p.TshirtNO).IsOptional();

            this.Property(p => p.BirthDate).IsOptional();

            this.Property(p => p.NameAlias).HasMaxLength(50).HasColumnName("Alias").IsOptional();

            this.HasRequired<Team>(p=>p.Team)
                .WithMany(p=>p.Players)
                .HasForeignKey(p=>p.TeamId)
                .WillCascadeOnDelete(false);

            this.HasRequired<Nationality>(p => p.Nationality)
                .WithMany()
                .HasForeignKey(p => p.NationalityId)
                .WillCascadeOnDelete(false);


        }
    }
}
