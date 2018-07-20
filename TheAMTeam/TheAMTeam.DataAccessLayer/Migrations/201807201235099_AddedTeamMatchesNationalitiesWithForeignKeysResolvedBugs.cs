namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamMatchesNationalitiesWithForeignKeysResolvedBugs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "PlayerId", "dbo.Players");
            DropIndex("dbo.Teams", new[] { "PlayerId" });
            AddColumn("dbo.Players", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Players", "Team_TeamId");
            AddForeignKey("dbo.Players", "Team_TeamId", "dbo.Teams", "TeamId");
            DropColumn("dbo.Teams", "PlayerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "PlayerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Players", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "Team_TeamId" });
            DropColumn("dbo.Players", "Team_TeamId");
            CreateIndex("dbo.Teams", "PlayerId");
            AddForeignKey("dbo.Teams", "PlayerId", "dbo.Players", "PlayerId", cascadeDelete: true);
        }
    }
}
