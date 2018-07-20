namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigrationDateAndCRUD : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "MessageDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "MessageDate", c => c.String());
        }
    }
}
