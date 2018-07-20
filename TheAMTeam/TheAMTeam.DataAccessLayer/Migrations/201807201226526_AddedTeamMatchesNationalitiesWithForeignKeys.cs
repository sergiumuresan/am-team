namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamMatchesNationalitiesWithForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Nationalities", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Teams", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.Nationalities", new[] { "Player_PlayerId" });
            DropIndex("dbo.Teams", new[] { "Player_PlayerId" });
            RenameColumn(table: "dbo.Nationalities", name: "Player_PlayerId", newName: "PlayerId");
            RenameColumn(table: "dbo.Teams", name: "Player_PlayerId", newName: "PlayerId");
            AlterColumn("dbo.Nationalities", "PlayerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teams", "PlayerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Nationalities", "PlayerId");
            CreateIndex("dbo.Teams", "PlayerId");
            AddForeignKey("dbo.Nationalities", "PlayerId", "dbo.Players", "PlayerId", cascadeDelete: true);
            AddForeignKey("dbo.Teams", "PlayerId", "dbo.Players", "PlayerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Nationalities", "PlayerId", "dbo.Players");
            DropIndex("dbo.Teams", new[] { "PlayerId" });
            DropIndex("dbo.Nationalities", new[] { "PlayerId" });
            AlterColumn("dbo.Teams", "PlayerId", c => c.Int());
            AlterColumn("dbo.Nationalities", "PlayerId", c => c.Int());
            RenameColumn(table: "dbo.Teams", name: "PlayerId", newName: "Player_PlayerId");
            RenameColumn(table: "dbo.Nationalities", name: "PlayerId", newName: "Player_PlayerId");
            CreateIndex("dbo.Teams", "Player_PlayerId");
            CreateIndex("dbo.Nationalities", "Player_PlayerId");
            AddForeignKey("dbo.Teams", "Player_PlayerId", "dbo.Players", "PlayerId");
            AddForeignKey("dbo.Nationalities", "Player_PlayerId", "dbo.Players", "PlayerId");
        }
    }
}
