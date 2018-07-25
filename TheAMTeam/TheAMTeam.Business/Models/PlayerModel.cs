using System;

namespace TheAMTeam.Business.Models
{
    public class PlayerModel
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int TshirtNO { get; set; }

        public DateTime? BirthDate { get; set; }

        public string NameAlias { get; set; }

        public int? NationalityId { get; set; }

        public int TeamId { get; set; }
       
        public TeamModel team { get; set; }
        
    }
}