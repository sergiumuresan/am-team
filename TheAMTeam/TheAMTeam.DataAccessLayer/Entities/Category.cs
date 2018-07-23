using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Category
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
