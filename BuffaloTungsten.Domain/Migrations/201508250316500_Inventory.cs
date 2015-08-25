namespace BuffaloTungsten.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_Id = c.Int(),
                        LotType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LotTypes", t => t.LotType_Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.LotType_Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LotNumber = c.String(maxLength: 25),
                        CycleStart = c.Int(nullable: false),
                        CycleEnd = c.Int(nullable: false),
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
                        LotType_Id = c.Int(),
                        Manufacturer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Furnaces", t => t.Furnace_Id)
                .ForeignKey("dbo.InventoryTypes", t => t.InventoryType_Id)
                .ForeignKey("dbo.LotTypes", t => t.LotType_Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.Categories", t => t.Product_Id)
                .Index(t => new { t.LotNumber, t.CycleStart, t.CycleEnd }, name: "IX_LotAndCycles")
                .Index(t => t.Customer_Id)
                .Index(t => t.Furnace_Id)
                .Index(t => t.InventoryType_Id)
                .Index(t => t.LotType_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.LotTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.Inventories", "Product_Id", "dbo.Categories");
            DropForeignKey("dbo.Inventories", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Categories", "LotType_Id", "dbo.LotTypes");
            DropForeignKey("dbo.Inventories", "LotType_Id", "dbo.LotTypes");
            DropForeignKey("dbo.Inventories", "InventoryType_Id", "dbo.InventoryTypes");
            DropForeignKey("dbo.Inventories", "Furnace_Id", "dbo.Furnaces");
            DropForeignKey("dbo.Inventories", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.LotTypes", new[] { "Name" });
            DropIndex("dbo.Inventories", new[] { "Product_Id" });
            DropIndex("dbo.Inventories", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Inventories", new[] { "LotType_Id" });
            DropIndex("dbo.Inventories", new[] { "InventoryType_Id" });
            DropIndex("dbo.Inventories", new[] { "Furnace_Id" });
            DropIndex("dbo.Inventories", new[] { "Customer_Id" });
            DropIndex("dbo.Inventories", "IX_LotAndCycles");
            DropIndex("dbo.Categories", new[] { "LotType_Id" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropTable("dbo.Manufacturers");
            DropTable("dbo.LotTypes");
            DropTable("dbo.InventoryTypes");
            DropTable("dbo.Furnaces");
            DropTable("dbo.Customers");
            DropTable("dbo.Inventories");
            DropTable("dbo.Categories");
        }
    }
}
