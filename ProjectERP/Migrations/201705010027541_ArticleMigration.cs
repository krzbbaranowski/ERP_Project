namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleCode = c.String(),
                        ArticleName = c.String(),
                        ArticleQuantity = c.Double(nullable: false),
                        ArticleCount = c.Double(nullable: false),
                        ArticleEan = c.String(),
                        ArticleMeasure_Id = c.Int(),
                        ArticleTax_Id = c.Int(),
                        ArticleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleMeasures", t => t.ArticleMeasure_Id)
                .ForeignKey("dbo.Taxes", t => t.ArticleTax_Id)
                .ForeignKey("dbo.ArticleTypes", t => t.ArticleType_Id)
                .Index(t => t.ArticleMeasure_Id)
                .Index(t => t.ArticleTax_Id)
                .Index(t => t.ArticleType_Id);
            
            CreateTable(
                "dbo.ArticleMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleMeasureName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticlePrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticlePriceName = c.String(),
                        ArticlePriceValueNetto = c.Double(nullable: false),
                        ArticlePriceValueBrutto = c.Double(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaxValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleGroupCode = c.String(),
                        ArticleGroupName = c.String(),
                        MastyerArticleGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleGroups", t => t.MastyerArticleGroup_Id)
                .Index(t => t.MastyerArticleGroup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleGroups", "MastyerArticleGroup_Id", "dbo.ArticleGroups");
            DropForeignKey("dbo.Articles", "ArticleType_Id", "dbo.ArticleTypes");
            DropForeignKey("dbo.Articles", "ArticleTax_Id", "dbo.Taxes");
            DropForeignKey("dbo.ArticlePrices", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ArticleMeasure_Id", "dbo.ArticleMeasures");
            DropIndex("dbo.ArticleGroups", new[] { "MastyerArticleGroup_Id" });
            DropIndex("dbo.ArticlePrices", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "ArticleType_Id" });
            DropIndex("dbo.Articles", new[] { "ArticleTax_Id" });
            DropIndex("dbo.Articles", new[] { "ArticleMeasure_Id" });
            DropTable("dbo.ArticleGroups");
            DropTable("dbo.ArticleTypes");
            DropTable("dbo.Taxes");
            DropTable("dbo.ArticlePrices");
            DropTable("dbo.ArticleMeasures");
            DropTable("dbo.Articles");
        }
    }
}
