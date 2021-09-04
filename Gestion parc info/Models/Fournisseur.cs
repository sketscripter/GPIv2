using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class Fournisseur
    {
        [Key]
        public int CodeFournisseur { get; set; }

        public String NomFournisseur { get; set; }

        public String Adresse { get; set; }

        public int Telephone { get; set; }

        public int Fax { get; set; }

        public String Email { get; set; }
    }
}