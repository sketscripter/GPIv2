using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.ViewModels
{
    public class MaterielViewModel
    {
        public Materiel Materiel { get; set; }
        public Utilisateur Utilsateur { get; set; }

        public ContratMaintenance ContratMaintenance { get; set; }

        public List<Caracteristique> Caracteristiques { get; set; }
    }
}