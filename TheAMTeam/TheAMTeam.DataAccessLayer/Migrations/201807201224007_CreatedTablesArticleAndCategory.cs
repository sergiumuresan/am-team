namespace TheAMTeam.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTablesArticleAndCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "CategoryId_CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId_CategoryId" });
            RenameColumn(table: "dbo.Articles", name: "CategoryId_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            AlterColumn("dbo.Articles", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Articles", name: "CategoryId", newName: "CategoryId_CategoryId");
            CreateIndex("dbo.Articles", "CategoryId_CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
