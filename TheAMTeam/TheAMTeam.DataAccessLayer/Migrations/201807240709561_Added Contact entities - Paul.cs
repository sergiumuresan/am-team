namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactentitiesPaul : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        UserMessage = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Contacts", new[] { "DepartmentId" });
            DropTable("dbo.Departments");
            DropTable("dbo.Contacts");
        }
    }
}
