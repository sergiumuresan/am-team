namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesMatchTeamCompetitionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        CompetionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CompetionId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        FirstTeamScore = c.Int(nullable: false),
                        SecondTeamScore = c.Int(nullable: false),
                        MatchDate = c.DateTime(nullable: false),
                        CompId = c.Int(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                        FirstTeamId = c.Int(nullable: false),
                        SecondTeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.CompetitionTypes", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.FirstTeamId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.FirstTeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Coach = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "FirstTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "CompetitionId", "dbo.CompetitionTypes");
            DropIndex("dbo.Matches", new[] { "FirstTeamId" });
            DropIndex("dbo.Matches", new[] { "CompetitionId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.CompetitionTypes");
        }
    }
}
