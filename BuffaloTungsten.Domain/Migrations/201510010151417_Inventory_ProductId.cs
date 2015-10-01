namespace BuffaloTungsten.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventory_ProductId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "Product_Id", "dbo.Categories");
            DropIndex("dbo.Inventories", new[] { "Product_Id" });
            AlterColumn("dbo.Inventories", "Product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "Product_Id");
            AddForeignKey("dbo.Inventories", "Product_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Product_Id", "dbo.Categories");
            DropIndex("dbo.Inventories", new[] { "Product_Id" });
            AlterColumn("dbo.Inventories", "Product_Id", c => c.Int());
            CreateIndex("dbo.Inventories", "Product_Id");
            AddForeignKey("dbo.Inventories", "Product_Id", "dbo.Categories", "Id");
        }
    }
}
