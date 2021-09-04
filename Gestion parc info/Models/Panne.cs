using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class Panne
    {
        [Key]
        public int NBonMateriel { get; set; }

        public DateTime DateReparation { get; set; }

        public String Intervenant { get; set; }

        public int CodeMateriel { get; set; }

        public String ResponsableEmission { get; set; }

        public String ResponsableReception { get; set; }

        public String ResponsableControle { get; set; }


    }
}