namespace Gestion_parc_info.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipementetdirection2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipements", "Quantité", c => c.Int(nullable: false));
            DropColumn("dbo.Directions", "SignUpFree");
            DropColumn("dbo.Directions", "DurationInMonths");
            DropColumn("dbo.Directions", "DiscountRate");
            DropColumn("dbo.Equipements", "LastName");
            DropColumn("dbo.Equipements", "BirthDate");
            DropColumn("dbo.Equipements", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Equipements", "IDN");
            DropColumn("dbo.Equipements", "Email");
            DropColumn("dbo.Equipements", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipements", "Phone", c => c.String());
            AddColumn("dbo.Equipements", "Email", c => c.String());
            AddColumn("dbo.Equipements", "IDN", c => c.String(maxLength: 14));
            AddColumn("dbo.Equipements", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipements", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Equipements", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Directions", "DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Directions", "DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.Directions", "SignUpFree", c => c.Byte(nullable: false));
            DropColumn("dbo.Equipements", "Quantité");
        }
    }
}
