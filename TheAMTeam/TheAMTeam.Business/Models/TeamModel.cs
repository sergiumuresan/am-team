using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class TeamModel
    {
        public int TeamId { get; set; }
        [Required(ErrorMessage ="Name required.")]
        [StringLength(15)]
        public string Name { get; set; }
        [Required(ErrorMessage ="City required")]
        [StringLength(15)]
        public string City { get; set; }
        [Required(ErrorMessage ="Coach required")]
        [StringLength(15)]
        public string Coach { get; set; }

        public ICollection<PlayerModel> PlayersModel { get; set; }
    }
}