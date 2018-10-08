using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired();

            HasRequired(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey<int>(c => c.DepartmentId);
        }
    }
}
