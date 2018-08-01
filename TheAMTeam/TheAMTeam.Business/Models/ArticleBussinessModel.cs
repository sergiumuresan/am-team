using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class ArticleBussinessModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PublishedDate { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryModel Category { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}