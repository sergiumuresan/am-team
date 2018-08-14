using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Configuration
{
    class NationalityEntityConfiguration: EntityTypeConfiguration<Nationality>
    {
        public NationalityEntityConfiguration()
        {
            this.ToTable("Nationalities");

            this.HasKey(n => n.NationalityId);

            this.Property(n => n.Name).HasMaxLength(50).IsRequired();
            
            
            
        }
    }
}
