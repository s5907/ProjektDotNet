namespace ProjektDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Group : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(),
                        Player_Id = c.Int(nullable: false),
                        Trainer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id, cascadeDelete: false)
                .Index(t => t.Player_Id)
                .Index(t => t.Trainer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Groups", "Player_Id", "dbo.Players");
            DropIndex("dbo.Groups", new[] { "Trainer_Id" });
            DropIndex("dbo.Groups", new[] { "Player_Id" });
            DropTable("dbo.Groups");
        }
    }
}
