using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektDotNet.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Imie nazwisko")]
        public string Name { get; set; }
        //do zmiany
        [Display(Name="Posiada licencje")]
        public bool HasLicense { get; set; }

        public SportType SportType { get; set; }

        
        [Display(Name = "Dyscyplina")]
        public byte SportTypeId { get; set; }

        [Display(Name = "Data urodzenia")]
      
        public DateTime? Birthdate { get; set; }
    }
}