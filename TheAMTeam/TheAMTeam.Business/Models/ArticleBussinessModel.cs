using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class ArticleBussinessModel
    {
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [Column(TypeName = "datetime2")]
        public DateTime PublishedDate { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }

        public virtual CategoryModel Category { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}