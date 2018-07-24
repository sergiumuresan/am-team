namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTablesAfterMerge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        ImageURL = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
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
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        City = c.String(maxLength: 15),
                        Coach = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        TeamId = c.Int(nullable: false),
                        TshirtNO = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                        NameAlias = c.String(maxLength: 20),
                        NationalityId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NationalityId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nationalities", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "FirstTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "CompetitionId", "dbo.CompetitionTypes");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Nationalities", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Matches", new[] { "FirstTeamId" });
            DropIndex("dbo.Matches", new[] { "CompetitionId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropTable("dbo.Nationalities");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.CompetitionTypes");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
