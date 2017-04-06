namespace ProjectERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Province_Id = c.Int(nullable: false),
                        Counterparty_Id = c.Int(nullable: false),
                        Province_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.Province_Id1)
                .Index(t => t.Province_Id1);
            
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
                        REGON = c.String(),
                        PESEL = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Province_Id1", "dbo.Provinces");
            DropForeignKey("dbo.Counterparties", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Counterparties", new[] { "Address_Id" });
            DropIndex("dbo.Addresses", new[] { "Province_Id1" });
            DropTable("dbo.Provinces");
            DropTable("dbo.Counterparties");
            DropTable("dbo.Addresses");
        }
    }
}
