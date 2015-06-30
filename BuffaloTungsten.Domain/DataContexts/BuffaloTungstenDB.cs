using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BuffaloTungsten.Domain.Entities; 

namespace BuffaloTungsten.Domain.DataContexts
{
    public class BuffaloTungstenDB : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Furnace> Furnaces { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<InventoryType> InventoryTypes { get; set; }
    } 
}
