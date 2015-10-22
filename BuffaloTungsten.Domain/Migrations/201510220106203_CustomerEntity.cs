namespace BuffaloTungsten.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Customers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Customers", "Extension", c => c.String(maxLength: 10));
            AddColumn("dbo.Customers", "Email", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Notes", c => c.String(unicode: false));
            DropColumn("dbo.Customers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Name", c => c.String(maxLength: 75));
            DropColumn("dbo.Customers", "Notes");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Extension");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
        }
    }
}
