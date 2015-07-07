namespace BuffaloTungsten.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LotNumber = c.String(maxLength: 25),
                        CycleStart = c.Int(nullable: false),
                        CycleEnd = c.Int(nullable: false),
                        LotType = c.String(maxLength: 10),
                        SizeRange = c.String(maxLength: 25),
                        Date = c.DateTime(nullable: false),
                        StartBalance = c.Int(nullable: false),
                        Balance = c.Int(nullable: false),
                        FSSS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Scott = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(maxLength: 255),
                        Customer_Id = c.Int(),
                        Furnace_Id = c.Int(),
                        InventoryType_Id = c.Int(),
                        Manufacturer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Furnaces", t => t.Furnace_Id)
                .ForeignKey("dbo.InventoryTypes", t => t.InventoryType_Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => new { t.LotNumber, t.CycleStart, t.CycleEnd }, name: "IX_LotAndCycles")
                .Index(t => t.LotType)
                .Index(t => t.Customer_Id)
                .Index(t => t.Furnace_Id)
                .Index(t => t.InventoryType_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Furnaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_Id)
                .Index(t => t.ProductType_Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductType_Id", "dbo.ProductTypes");
            DropForeignKey("dbo.Inventories", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Inventories", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Inventories", "InventoryType_Id", "dbo.InventoryTypes");
            DropForeignKey("dbo.Inventories", "Furnace_Id", "dbo.Furnaces");
            DropForeignKey("dbo.Inventories", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "ProductType_Id" });
            DropIndex("dbo.Inventories", new[] { "Product_Id" });
            DropIndex("dbo.Inventories", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Inventories", new[] { "InventoryType_Id" });
            DropIndex("dbo.Inventories", new[] { "Furnace_Id" });
            DropIndex("dbo.Inventories", new[] { "Customer_Id" });
            DropIndex("dbo.Inventories", new[] { "LotType" });
            DropIndex("dbo.Inventories", "IX_LotAndCycles");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.InventoryTypes");
            DropTable("dbo.Furnaces");
            DropTable("dbo.Inventories");
            DropTable("dbo.Customers");
        }
    }
}
