using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}