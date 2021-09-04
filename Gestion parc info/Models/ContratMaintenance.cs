using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class ContratMaintenance

    {
        [Key]
        public int NumeroContrat { get; set; }

        public String Type { get; set; }

        public String Societe { get; set; }
        public int Telephone { get; set; }
        public int Fax { get; set; }
        public DateTime DateContrat { get; set; }

        public int Duree { get; set; }

        public double CoutPrestation { get; set; }

        public String Adresse { get; set; }

        public String Email { get; set; }


    }
}