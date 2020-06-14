using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektDotNet.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public Player Player { get; set; }

        [Required]
        public Trainer Trainer { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}