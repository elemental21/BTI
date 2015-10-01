namespace BuffaloTungsten.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventory_NullableForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Inventories", "Furnace_Id", "dbo.Furnaces");
            DropForeignKey("dbo.Inventories", "InventoryType_Id", "dbo.InventoryTypes");
            DropForeignKey("dbo.Inventories", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Inventories", new[] { "Furnace_Id" });
            DropIndex("dbo.Inventories", new[] { "InventoryType_Id" });
            DropIndex("dbo.Inventories", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Inventories", new[] { "Customer_Id" });
            AlterColumn("dbo.Inventories", "Furnace_Id", c => c.Int());
            AlterColumn("dbo.Inventories", "InventoryType_Id", c => c.Int());
            AlterColumn("dbo.Inventories", "Manufacturer_Id", c => c.Int());
            AlterColumn("dbo.Inventories", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Inventories", "Furnace_Id");
            CreateIndex("dbo.Inventories", "InventoryType_Id");
            CreateIndex("dbo.Inventories", "Manufacturer_Id");
            CreateIndex("dbo.Inventories", "Customer_Id");
            AddForeignKey("dbo.Inventories", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Inventories", "Furnace_Id", "dbo.Furnaces", "Id");
            AddForeignKey("dbo.Inventories", "InventoryType_Id", "dbo.InventoryTypes", "Id");
            AddForeignKey("dbo.Inventories", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Inventories", "InventoryType_Id", "dbo.InventoryTypes");
            DropForeignKey("dbo.Inventories", "Furnace_Id", "dbo.Furnaces");
            DropForeignKey("dbo.Inventories", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Inventories", new[] { "Customer_Id" });
            DropIndex("dbo.Inventories", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Inventories", new[] { "InventoryType_Id" });
            DropIndex("dbo.Inventories", new[] { "Furnace_Id" });
            AlterColumn("dbo.Inventories", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "Manufacturer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "InventoryType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "Furnace_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "Customer_Id");
            CreateIndex("dbo.Inventories", "Manufacturer_Id");
            CreateIndex("dbo.Inventories", "InventoryType_Id");
            CreateIndex("dbo.Inventories", "Furnace_Id");
            AddForeignKey("dbo.Inventories", "Manufacturer_Id", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "InventoryType_Id", "dbo.InventoryTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "Furnace_Id", "dbo.Furnaces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
