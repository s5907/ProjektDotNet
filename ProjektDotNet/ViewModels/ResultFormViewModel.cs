using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjektDotNet.Models;

namespace ProjektDotNet.ViewModels
{
    public class ResultFormViewModel
    {
        public IEnumerable<Competition> Competitions { get; set; }
        public IEnumerable<Player> Players { get; set; }

        public int? Id { get; set; }
        [Display(Name = "Nazwa zawodów")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Rodzaj zawodów")]
        [Required]
        public byte? CompetitionId { get; set; }

        [Display(Name = "Zawodnik")]
        [Required]
        public int PlayerId { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [Required]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Data zakńczenia")]
        [Required]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Miejsce")]
        public byte Place { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Result" : "New Result";
            }
        }

        public ResultFormViewModel()
        {
            Id = 0;
        }

        public ResultFormViewModel(Result result)
        {
            Id = result.Id;
            Name = result.Name;
            DateStart = result.DateStart;
            DateEnd = result.DateEnd;
            CompetitionId = result.CompetitionId;
            PlayerId = result.PlayerId;
            Place = result.Place;
        }
    }
}