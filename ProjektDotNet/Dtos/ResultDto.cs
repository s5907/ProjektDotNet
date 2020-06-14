using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektDotNet.Dtos
{
    public class ResultDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte CompetitionId { get; set; }
        [Required]
        public int PlayerId { get; set; }

        public CompetitionDto Competition { get; set; }
        public PlayerDto Player { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        [Range(1, 30)]
        public byte place { get; set; }
    }
}