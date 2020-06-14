using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektDotNet.Models
{
    public class Result
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Nazwa zawodów")]
        public string Name { get; set; }

        public Competition Competition { get; set; }
        public Player Player { get; set; }

        [Display(Name = "Zawody")]
        [Required]
        public byte CompetitionId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Data rozpoczęcia")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Data zakńczenia")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Miejsce")]
        public byte Place { get; set; }

    }
}