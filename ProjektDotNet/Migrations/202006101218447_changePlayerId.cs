namespace ProjektDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePlayerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Results", "Player_Id", "dbo.Players");
            DropIndex("dbo.Results", new[] { "Player_Id" });
            DropColumn("dbo.Results", "PlayerId");
            RenameColumn(table: "dbo.Results", name: "Player_Id", newName: "PlayerId");
            AlterColumn("dbo.Results", "PlayerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Results", "PlayerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Results", "PlayerId");
            AddForeignKey("dbo.Results", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "PlayerId", "dbo.Players");
            DropIndex("dbo.Results", new[] { "PlayerId" });
            AlterColumn("dbo.Results", "PlayerId", c => c.Int());
            AlterColumn("dbo.Results", "PlayerId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Results", name: "PlayerId", newName: "Player_Id");
            AddColumn("dbo.Results", "PlayerId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Results", "Player_Id");
            AddForeignKey("dbo.Results", "Player_Id", "dbo.Players", "Id");
        }
    }
}
