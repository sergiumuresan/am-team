using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheAMTeam.Business.ViewModel;

namespace TheAMTeam.Business.Models
{
    public class PlayerBusinessModel
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

        public TeamBusinessModel Team { get; set; }

        public NationalityModel Nationality { get; set; }

        //public IEnumerable<TeamModel> Teams { get; set; }


        //TODO

        //[Required]
        //[FutureDate]
        //public string Date { get; set; }

        //[Required]
        //[ValidationTime]
        //public string Time { get; set; }

        //public DateTime getBirthDate()
        //{
        //    return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        //}

    }
}