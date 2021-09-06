namespace Gestion_parc_info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstseed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affectations",
                c => new
                    {
                        NBonAffectation = c.Int(nullable: false, identity: true),
                        CodeMateriel = c.Int(nullable: false),
                        Structure = c.String(),
                        ResponsableEmission = c.String(),
                        ResponsableReception = c.String(),
                        ResponsableControle = c.String(),
                        IdUtilisateur = c.Int(nullable: false),
                        DateAffectation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NBonAffectation);
            
            CreateTable(
                "dbo.Caracteristiques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomCaracteristique = c.String(),
                        CodeMateriel = c.Double(nullable: false),
                        Materiel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materiels", t => t.Materiel_Id)
                .Index(t => t.Materiel_Id);
            
            CreateTable(
                "dbo.ContratMaintenances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Societe = c.String(),
                        Telephone = c.Int(nullable: false),
                        Fax = c.Int(nullable: false),
                        DateContrat = c.DateTime(nullable: false),
                        Duree = c.Int(nullable: false),
                        CoutPrestation = c.Double(nullable: false),
                        Adresse = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        CodeFournisseur = c.Int(nullable: false, identity: true),
                        NomFournisseur = c.String(),
                        Adresse = c.String(),
                        Telephone = c.Int(nullable: false),
                        Fax = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CodeFournisseur);
            
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateService = c.DateTime(nullable: false),
                        EtatMateriel = c.String(),
                        Maintenance = c.Boolean(nullable: false),
                        Observations = c.String(),
                        Type = c.String(),
                        Marque = c.String(),
                        Modele = c.String(),
                        Designation = c.String(),
                        UtilisateurId = c.Byte(nullable: false),
                        ContratMaintenanceId = c.Byte(nullable: false),
                        CaracteristiquesId = c.Byte(nullable: false),
                        ContratMaintenance_Id = c.Int(),
                        Fournisseur_CodeFournisseur = c.Int(),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContratMaintenances", t => t.ContratMaintenance_Id)
                .ForeignKey("dbo.Fournisseurs", t => t.Fournisseur_CodeFournisseur)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .Index(t => t.ContratMaintenance_Id)
                .Index(t => t.Fournisseur_CodeFournisseur)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        MotDePasse = c.String(),
                        Role = c.Int(nullable: false),
                        Structure = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pannes",
                c => new
                    {
                        NBonMateriel = c.Int(nullable: false, identity: true),
                        DateReparation = c.DateTime(nullable: false),
                        Intervenant = c.String(),
                        CodeMateriel = c.Int(nullable: false),
                        ResponsableEmission = c.String(),
                        ResponsableReception = c.String(),
                        ResponsableControle = c.String(),
                    })
                .PrimaryKey(t => t.NBonMateriel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materiels", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Materiels", "Fournisseur_CodeFournisseur", "dbo.Fournisseurs");
            DropForeignKey("dbo.Materiels", "ContratMaintenance_Id", "dbo.ContratMaintenances");
            DropForeignKey("dbo.Caracteristiques", "Materiel_Id", "dbo.Materiels");
            DropIndex("dbo.Materiels", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Materiels", new[] { "Fournisseur_CodeFournisseur" });
            DropIndex("dbo.Materiels", new[] { "ContratMaintenance_Id" });
            DropIndex("dbo.Caracteristiques", new[] { "Materiel_Id" });
            DropTable("dbo.Pannes");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Materiels");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.ContratMaintenances");
            DropTable("dbo.Caracteristiques");
            DropTable("dbo.Affectations");
        }
    }
}
