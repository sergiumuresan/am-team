using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        
        public string Name { get; set; }

        public int TeamId { get; set; }

        public int TshirtNO { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string NameAlias { get; set; }

        public int NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }
        
        public virtual Team Team { get; set; }
    }
}
