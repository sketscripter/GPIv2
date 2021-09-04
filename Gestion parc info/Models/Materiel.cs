using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Gestion_parc_info.Models
{
    public class Materiel
    {
        [Key]
        public int NumeroDeSerie { get; set; }

        public Fournisseur Fournisseur { get; set; }

        public DateTime DateService { get; set; }

        public String EtatMateriel { get; set; }

        public bool Maintenance { get; set; }

        public String Observations { get; set; }

        public String Type { get; set; }

        public String Marque { get; set; }

        public String Modele { get; set; }

        public String Designation { get; set; }

        public Utilisateur Utilisateur { get; set; }

        public ContratMaintenance ContratMaintenance { get; set; }

        public List<Caracteristique> Caracteristiques { get; set; }


    }
}