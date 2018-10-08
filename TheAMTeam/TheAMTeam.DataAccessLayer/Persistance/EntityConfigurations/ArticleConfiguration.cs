using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            Property(a => a.ArticleId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}
