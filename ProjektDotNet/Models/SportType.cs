using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektDotNet.Models
{
    public class SportType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Club { get; set; }
        public string Coach { get; set; }

    }
}