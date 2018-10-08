using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class PlayerModel
    {
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Name required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "TShirt required.")]
        public int TshirtNO { get; set; }

        public DateTime? BirthDate { get; set; }

        public string NameAlias { get; set; }

        [Required(ErrorMessage = "nationality required.")]
        public int? NationalityId { get; set; }

        [Required(ErrorMessage = "Team required.")]
        public int TeamId { get; set; }

        public TeamModel Team { get; set; }

        public NationalityModel Nationality { get; set; }

        public VoteModel Vote { get; set; }
    }
}