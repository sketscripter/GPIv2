namespace Gestion_parc_info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materielv3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caracteristiques", "Materiel_Id", "dbo.Materiels");
            DropIndex("dbo.Caracteristiques", new[] { "Materiel_Id" });
            AddColumn("dbo.Materiels", "Caracteristique_Id", c => c.Int());
            CreateIndex("dbo.Materiels", "Caracteristique_Id");
            AddForeignKey("dbo.Materiels", "Caracteristique_Id", "dbo.Caracteristiques", "Id");
            DropColumn("dbo.Caracteristiques", "Materiel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caracteristiques", "Materiel_Id", c => c.Int());
            DropForeignKey("dbo.Materiels", "Caracteristique_Id", "dbo.Caracteristiques");
            DropIndex("dbo.Materiels", new[] { "Caracteristique_Id" });
            DropColumn("dbo.Materiels", "Caracteristique_Id");
            CreateIndex("dbo.Caracteristiques", "Materiel_Id");
            AddForeignKey("dbo.Caracteristiques", "Materiel_Id", "dbo.Materiels", "Id");
        }
    }
}
