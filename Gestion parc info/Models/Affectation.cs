using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class Affectation
    {
        [Key]
        public int NBonAffectation { get; set; }

        public int CodeMateriel { get; set; }

        public String Structure { get; set; }

        public String ResponsableEmission { get; set; }

        public String ResponsableReception { get; set; }

        public String ResponsableControle { get; set; }


        public int IdUtilisateur { get; set; }

        public DateTime DateAffectation { get; set; }
    }
}