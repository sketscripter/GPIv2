using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.ViewModels
{
    public class equipementViewModel
    {
        
            public Equipement Equipement { get; set; }
            public IEnumerable<Direction> Directions { get; set; }
        
    }
}