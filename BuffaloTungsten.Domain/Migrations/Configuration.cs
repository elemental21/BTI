namespace BuffaloTungsten.Domain.Migrations
{
    using BuffaloTungsten.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BuffaloTungsten.Domain.DataContexts.BuffaloTungstenDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BuffaloTungsten.Domain.DataContexts.BuffaloTungstenDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ProductTypes.AddOrUpdate(
                p => p.Name,
                new ProductType { Name = "W Powder" },
                new ProductType { Name = "Crushed Carbide" },
                new ProductType { Name = "Rod" },
                new ProductType { Name = "Consignment" },
                new ProductType { Name = "Toll Powder" },
                new ProductType { Name = "Ore" },
                new ProductType { Name = "Mo Powder" }
                );
            var powder = context.ProductTypes.Where(x => x.Name == "W Powder").FirstOrDefault();
            context.Products.AddOrUpdate(
                p => p.Name,        
                new Product { ProductType = powder, Name = "APT" },
                new Product { ProductType = powder, Name = "Oxide" },
                new Product { ProductType = powder, Name = "" }
                );
        }
    }
}
