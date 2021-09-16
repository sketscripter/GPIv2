using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Gestion_parc_info.Models
{
    public class Materiel
    {
        
        public int Id { get; set; }

        public Fournisseur Fournisseur { get; set; }
        [Required]

        public byte FournisseurId { get; set; }

        public DateTime DateService { get; set; }

        public String EtatMateriel { get; set; }

        public bool Maintenance { get; set; }

        public String Observations { get; set; }

        public String Type { get; set; }

        public String Marque { get; set; }

        public String Modele { get; set; }

        public String Designation { get; set; }

        public Utilisateur Utilisateur { get; set; }
        [Required]
        public byte UtilisateurId { get; set; }

        public ContratMaintenance ContratMaintenance { get; set; }
        [Required]
        public byte ContratMaintenanceId { get; set; }

        public Caracteristique Caracteristique { get; set; }
        [Required]
        public byte CaracteristiquesId { get; set; }


    }
}