namespace Gestion_parc_info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipementetdirection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directions",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignUpFree = c.Byte(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        BirthDate = c.DateTime(),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        DirectionId = c.Byte(nullable: false),
                        IDN = c.String(maxLength: 14),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directions", t => t.DirectionId, cascadeDelete: true)
                .Index(t => t.DirectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipements", "DirectionId", "dbo.Directions");
            DropIndex("dbo.Equipements", new[] { "DirectionId" });
            DropTable("dbo.Equipements");
            DropTable("dbo.Directions");
        }
    }
}
