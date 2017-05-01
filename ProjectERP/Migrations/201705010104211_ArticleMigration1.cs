namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticlePrices", "ArticleId", "dbo.Articles");
            AddColumn("dbo.Articles", "DefaultArticlePrice_Id", c => c.Int());
            AddColumn("dbo.ArticlePrices", "Article_Id", c => c.Int());
            CreateIndex("dbo.Articles", "DefaultArticlePrice_Id");
            CreateIndex("dbo.ArticlePrices", "Article_Id");
            AddForeignKey("dbo.Articles", "DefaultArticlePrice_Id", "dbo.ArticlePrices", "Id");
            AddForeignKey("dbo.ArticlePrices", "Article_Id", "dbo.Articles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticlePrices", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Articles", "DefaultArticlePrice_Id", "dbo.ArticlePrices");
            DropIndex("dbo.ArticlePrices", new[] { "Article_Id" });
            DropIndex("dbo.Articles", new[] { "DefaultArticlePrice_Id" });
            DropColumn("dbo.ArticlePrices", "Article_Id");
            DropColumn("dbo.Articles", "DefaultArticlePrice_Id");
            AddForeignKey("dbo.ArticlePrices", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
