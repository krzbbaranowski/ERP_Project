namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticlePriceTypes", "ArticlePriceName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticlePriceTypes", "ArticlePriceName");
        }
    }
}
