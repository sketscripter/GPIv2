using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.ViewModels
{
    public class materielViewModel
    {
        public Materiel Materiel { get; set; }

        public IEnumerable<Fournisseur> Fournisseurs { get; set; }

        public IEnumerable<Utilisateur> Utilisateurs { get; set; }
        

        public IEnumerable<ContratMaintenance> ContratMaintenances { get; set; }
        

        public IEnumerable<Caracteristique> Caracteristiques { get; set; }
       
    }
}