namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigrationForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DepartmentId_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "DepartmentId_Id");
            AddForeignKey("dbo.Contacts", "DepartmentId_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "DepartmentId_Id", "dbo.Departments");
            DropIndex("dbo.Contacts", new[] { "DepartmentId_Id" });
            DropColumn("dbo.Contacts", "DepartmentId_Id");
        }
    }
}
