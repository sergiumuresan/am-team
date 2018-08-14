namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CompetionId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        FirstTeamScore = c.Int(nullable: false),
                        SecondTeamScore = c.Int(nullable: false),
                        MatchDate = c.DateTime(),
                        CompetitionId = c.Int(nullable: false),
                        FirstId = c.Int(nullable: false),
                        SecondId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.FirstId)
                .ForeignKey("dbo.Teams", t => t.SecondId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.FirstId)
                .Index(t => t.SecondId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        Coach = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TeamId = c.Int(nullable: false),
                        TshirtNO = c.Int(),
                        BirthDate = c.DateTime(),
                        Alias = c.String(maxLength: 50),
                        NationalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Players_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.NationalityId)
                .ForeignKey("dbo.Players", t => t.Players_PlayerId)
                .Index(t => t.Players_PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Matches", "SecondId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "FirstId", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Nationalities", "Players_PlayerId", "dbo.Players");
            DropIndex("dbo.Nationalities", new[] { "Players_PlayerId" });
            DropIndex("dbo.Players", new[] { "NationalityId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Matches", new[] { "SecondId" });
            DropIndex("dbo.Matches", new[] { "FirstId" });
            DropIndex("dbo.Matches", new[] { "CompetitionId" });
            DropTable("dbo.Nationalities");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.Competitions");
        }
    }
}
