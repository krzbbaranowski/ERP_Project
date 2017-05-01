namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticlePrices", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.ArticlePrices", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticlePrices", new[] { "ArticleId" });
            DropIndex("dbo.ArticlePrices", new[] { "Article_Id" });
            DropColumn("dbo.ArticlePrices", "Article_Id");
            RenameColumn(table: "dbo.ArticlePrices", name: "ArticleId", newName: "Article_Id");
            RenameColumn(table: "dbo.ArticleGroups", name: "MastyerArticleGroup_Id", newName: "MasterArticleGroup_Id");
            RenameIndex(table: "dbo.ArticleGroups", name: "IX_MastyerArticleGroup_Id", newName: "IX_MasterArticleGroup_Id");
            AddColumn("dbo.ArticlePrices", "Article_Id1", c => c.Int());
            AlterColumn("dbo.ArticlePrices", "Article_Id", c => c.Int());
            CreateIndex("dbo.ArticlePrices", "Article_Id");
            CreateIndex("dbo.ArticlePrices", "Article_Id1");
            AddForeignKey("dbo.ArticlePrices", "Article_Id1", "dbo.Articles", "Id");
            AddForeignKey("dbo.ArticlePrices", "Article_Id", "dbo.Articles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticlePrices", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.ArticlePrices", "Article_Id1", "dbo.Articles");
            DropIndex("dbo.ArticlePrices", new[] { "Article_Id1" });
            DropIndex("dbo.ArticlePrices", new[] { "Article_Id" });
            AlterColumn("dbo.ArticlePrices", "Article_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ArticlePrices", "Article_Id1");
            RenameIndex(table: "dbo.ArticleGroups", name: "IX_MasterArticleGroup_Id", newName: "IX_MastyerArticleGroup_Id");
            RenameColumn(table: "dbo.ArticleGroups", name: "MasterArticleGroup_Id", newName: "MastyerArticleGroup_Id");
            RenameColumn(table: "dbo.ArticlePrices", name: "Article_Id", newName: "ArticleId");
            AddColumn("dbo.ArticlePrices", "Article_Id", c => c.Int());
            CreateIndex("dbo.ArticlePrices", "Article_Id");
            CreateIndex("dbo.ArticlePrices", "ArticleId");
            AddForeignKey("dbo.ArticlePrices", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArticlePrices", "Article_Id", "dbo.Articles", "Id");
        }
    }
}
