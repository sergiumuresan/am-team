using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheAMTeam.Business.Models
{
    public class PlayerModel
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int TeamId { get; set; }

        public int TshirtNO { get; set; }

        public DateTime? BirthDate { get; set; }

        public string NameAlias { get; set; }

        public int? NationalityId { get; set; }

        
    }
}