namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticlePriceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ArticlePrices", "ArticlePriceType_Id", c => c.Int());
            CreateIndex("dbo.ArticlePrices", "ArticlePriceType_Id");
            AddForeignKey("dbo.ArticlePrices", "ArticlePriceType_Id", "dbo.ArticlePriceTypes", "Id");
            DropColumn("dbo.ArticlePrices", "ArticlePriceName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArticlePrices", "ArticlePriceName", c => c.String());
            DropForeignKey("dbo.ArticlePrices", "ArticlePriceType_Id", "dbo.ArticlePriceTypes");
            DropIndex("dbo.ArticlePrices", new[] { "ArticlePriceType_Id" });
            DropColumn("dbo.ArticlePrices", "ArticlePriceType_Id");
            DropTable("dbo.ArticlePriceTypes");
        }
    }
}
