namespace ProjektDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class License : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "HasLicense", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trainers", "HasLicense", c => c.Boolean(nullable: false));
            AddColumn("dbo.Zawodniks", "HasLicense", c => c.Boolean(nullable: false));
            DropColumn("dbo.Players", "IsSubscribedToNewsletter");
            DropColumn("dbo.Trainers", "IsSubscribedToNewsletter");
            DropColumn("dbo.Zawodniks", "IsSubscribedToNewsletter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zawodniks", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trainers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Zawodniks", "HasLicense");
            DropColumn("dbo.Trainers", "HasLicense");
            DropColumn("dbo.Players", "HasLicense");
        }
    }
}
