using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}