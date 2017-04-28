namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codefirst4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Street = c.String(),
                        House = c.Int(nullable: false),
                        Flat = c.Int(nullable: false),
                        PostalCode = c.String(),
                        City = c.String(),
                        Telephone = c.String(),
                        Telephone2 = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Url = c.String(),
                        Province = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Counterparties", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Counterparties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name1 = c.String(),
                        Name2 = c.String(),
                        Name3 = c.String(),
                        NIP = c.String(),
                        Regon = c.String(),
                        Pesel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Id", "dbo.Counterparties");
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.Counterparties");
            DropTable("dbo.Addresses");
        }
    }
}
