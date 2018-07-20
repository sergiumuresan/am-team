namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllDone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Player_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.NationalityId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .Index(t => t.Player_PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Team = c.Int(nullable: false),
                        TshirtNO = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                        NameAlias = c.String(maxLength: 20),
                        NationalityId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        City = c.String(maxLength: 15),
                        Coach = c.String(maxLength: 15),
                        Player_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .Index(t => t.Player_PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Nationalities", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.Teams", new[] { "Player_PlayerId" });
            DropIndex("dbo.Nationalities", new[] { "Player_PlayerId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
            DropTable("dbo.Nationalities");
        }
    }
}
