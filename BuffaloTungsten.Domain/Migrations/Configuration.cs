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

            context.LotTypes.AddOrUpdate(
                p => p.Name,
                new LotType { Name = "receiving" },
                new LotType { Name = "production" },
                new LotType { Name = "finished" }
                );

            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Name = "W Powder" },
                new Category { Name = "Crushed Carbide" },
                new Category { Name = "Rod" },
                new Category { Name = "Consignment" },
                new Category { Name = "Toll Powder" },
                new Category { Name = "Ore" },
                new Category { Name = "Mo Powder" }
                );
            // This has to be run here otheriwse the above parent categories will be null when assigned to the children below
            context.SaveChanges();
            //var powder = context.Categories.Add(new Category() { Name = "W Powder" });

            var powder = context.Categories.Where(x => x.Name == "W Powder").FirstOrDefault();
            var finished = context.LotTypes.Where(x => x.Name == "finished").FirstOrDefault();

            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category { Parent = powder, LotType = finished, Name = "APT" },
                new Category { Parent = powder, LotType = finished, Name = "Oxide" }
                //new Category { ProductType = powder, Name = "" }
                );


            //context.Categories.Add(new Category()
            //    {
            //        Name = "APT",
            //        LotType = finished,
            //        Parent = powder
            //    });
        }
    }
}
