using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektDotNet.Models
{
    public class Trainer
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Imie Nazwisko")]
        public string Name { get; set; }

        [Display(Name = "Posiada licencje")]
        public bool HasLicense { get; set; }

        [Display(Name = "Data urodzenia")]
        
        public DateTime? Birthdate { get; set; }

        public Player Player { get; set; }

        [Required]
        [Display(Name = "Zawodnik")]
        public int PlayerId { get; set; }

        
        public SportType SportType { get; set; }

        [Display(Name = "Dyscyplina")]
        public byte SportTypeId { get; set; }

        
    }
}