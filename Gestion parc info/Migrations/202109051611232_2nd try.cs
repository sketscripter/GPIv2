namespace Gestion_parc_info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndtry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materiels", "FournisseurId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materiels", "FournisseurId");
        }
    }
}
