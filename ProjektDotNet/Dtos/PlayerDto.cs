﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektDotNet.Dtos
{

    public class PlayerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool HasLicense { get; set; }

      

        public byte SportTypeId { get; set; }

        public SportTypeDto SportType { get; set; }

       
        public DateTime? Birthdate { get; set; }
    }
}