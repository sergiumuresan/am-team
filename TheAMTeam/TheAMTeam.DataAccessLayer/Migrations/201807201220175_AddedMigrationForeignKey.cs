namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigrationForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "DepartmentId");
            AddForeignKey("dbo.Contacts", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Contacts", new[] { "DepartmentId" });
            DropColumn("dbo.Contacts", "DepartmentId");
        }
    }
}
