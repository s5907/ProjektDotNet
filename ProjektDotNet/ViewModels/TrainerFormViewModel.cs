using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektDotNet.Models;

namespace ProjektDotNet.ViewModels
{
    public class TrainerFormViewModel
    {
        public Trainer Trainer { get; set; }
        public IEnumerable<SportType> SportTypes { get; set; }
        public IEnumerable<Player> Players { get; set; }
        
    }
}