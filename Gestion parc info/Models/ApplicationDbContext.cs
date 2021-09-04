using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gestion_parc_info.Models
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext() : base("LocalDbOnee")
            {

            }

            public DbSet<Materiel> Materiels { get; set; }
            public DbSet<Utilisateur> Utilisateurs { get; set; }
            public DbSet<Fournisseur> Fournisseurs { get; set; }
            public DbSet<Panne> Pannes { get; set; }

        public DbSet<ContratMaintenance> ContratMaintenances { get; set; }

        public DbSet<Caracteristique> Caracteristiques { get; set; }

        public DbSet<Affectation> Affectations { get; set; }




    }


}