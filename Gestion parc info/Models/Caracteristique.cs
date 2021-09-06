using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class Caracteristique
    {
        public String NomCaracteristique { get; set; }

        public double CodeMateriel { get; set; }
        [Key]
        public int Id { get; set; }
    }
}