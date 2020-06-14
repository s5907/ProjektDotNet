namespace ProjektDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Treiner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(),
                        PlayerId = c.Int(nullable: false),
                        SportTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.SportTypes", t => t.SportTypeId, cascadeDelete: false)
                .Index(t => t.PlayerId)
                .Index(t => t.SportTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "SportTypeId", "dbo.SportTypes");
            DropForeignKey("dbo.Trainers", "PlayerId", "dbo.Players");
            DropIndex("dbo.Trainers", new[] { "SportTypeId" });
            DropIndex("dbo.Trainers", new[] { "PlayerId" });
            DropTable("dbo.Trainers");
        }
    }
}
