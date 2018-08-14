using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }
        
        public virtual Player Players { get; set; }

    }
}
