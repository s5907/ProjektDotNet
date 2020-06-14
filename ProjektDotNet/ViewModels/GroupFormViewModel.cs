using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektDotNet.Models;

namespace ProjektDotNet.ViewModels
{
    public class GroupFormViewModel
    {
        public IEnumerable<Trainer> Trainers { get; set; }
        public Player Player { get; set; }
    }
}