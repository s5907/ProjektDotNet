using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektDotNet.Models;

namespace ProjektDotNet.ViewModels
{
    public class PlayerFormViewModel
    {
        public IEnumerable<SportType> SportTypes { get; set; }
        public Player Player { get; set; }
    }
}