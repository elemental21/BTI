namespace BuffaloTungsten.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactsCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Customers", new[] { "Contact_Id" });
            DropIndex("dbo.Contacts", new[] { "Customer_Id" });
            AddColumn("dbo.Contacts", "IsPrimary", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contacts", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "Customer_Id");
            DropColumn("dbo.Customers", "Contact_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Contact_Id", c => c.Int());
            DropIndex("dbo.Contacts", new[] { "Customer_Id" });
            AlterColumn("dbo.Contacts", "Customer_Id", c => c.Int());
            DropColumn("dbo.Contacts", "IsPrimary");
            CreateIndex("dbo.Contacts", "Customer_Id");
            CreateIndex("dbo.Customers", "Contact_Id");
            AddForeignKey("dbo.Customers", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
