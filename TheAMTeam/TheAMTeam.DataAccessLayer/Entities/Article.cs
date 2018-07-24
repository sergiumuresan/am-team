using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Article
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ArticleId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime PublishedDate { get; set; }
            public string Content { get; set; }
            public string ImageURL { get; set; }
            public int CategoryId { get; set; }

            [ForeignKey("CategoryId")]
            public virtual Category Category { get; set; }
        
        }
}
