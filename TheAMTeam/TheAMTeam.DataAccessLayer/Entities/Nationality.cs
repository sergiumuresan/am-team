using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }
        

        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
