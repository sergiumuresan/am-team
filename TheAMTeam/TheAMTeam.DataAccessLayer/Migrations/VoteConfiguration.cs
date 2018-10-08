using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Migrations
{
    public class VoteConfiguration : EntityTypeConfiguration<Vote> 
    {
        public VoteConfiguration()
        {
            Property(v => v.NumOfVotes)
                .IsRequired();

        

            //HasRequired(v => v.Player)
            //    .WithMany()
            //    .HasForeignKey(v => v.Id);
        }
    }
}
