namespace Gestion_parc_info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newseed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Affectations", "Structure_StructureId", "dbo.Structures");
            DropForeignKey("dbo.Utilisateurs", "Structure_StructureId", "dbo.Structures");
            DropIndex("dbo.Affectations", new[] { "Structure_StructureId" });
            DropIndex("dbo.Utilisateurs", new[] { "Structure_StructureId" });
            AddColumn("dbo.Affectations", "Structure", c => c.String());
            AddColumn("dbo.Utilisateurs", "Structure", c => c.String());
            AlterColumn("dbo.Utilisateurs", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Affectations", "Structure_StructureId");
            DropColumn("dbo.Utilisateurs", "StructureId");
            DropColumn("dbo.Utilisateurs", "Structure_StructureId");
            DropTable("dbo.Structures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        StructureId = c.Int(nullable: false, identity: true),
                        NomStructure = c.String(),
                        IDPole = c.Int(),
                        IDDirection = c.Int(),
                        IDDivision = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StructureId);
            
            AddColumn("dbo.Utilisateurs", "Structure_StructureId", c => c.Int());
            AddColumn("dbo.Utilisateurs", "StructureId", c => c.Byte(nullable: false));
            AddColumn("dbo.Affectations", "Structure_StructureId", c => c.Int());
            AlterColumn("dbo.Utilisateurs", "Role", c => c.String());
            DropColumn("dbo.Utilisateurs", "Structure");
            DropColumn("dbo.Affectations", "Structure");
            CreateIndex("dbo.Utilisateurs", "Structure_StructureId");
            CreateIndex("dbo.Affectations", "Structure_StructureId");
            AddForeignKey("dbo.Utilisateurs", "Structure_StructureId", "dbo.Structures", "StructureId");
            AddForeignKey("dbo.Affectations", "Structure_StructureId", "dbo.Structures", "StructureId");
        }
    }
}
