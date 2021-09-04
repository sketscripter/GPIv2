using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
    public class Utilisateur
    {
        [Key]
        public int Matricule { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public String MotDePasse { get; set; }
        public Role Role { get; set; }

        public String Structure { get; set; }
    }

    public enum Role { 
    Admin,
    User}
}