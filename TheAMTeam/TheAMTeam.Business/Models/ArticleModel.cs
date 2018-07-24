using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}