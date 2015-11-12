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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Furnace> Furnaces { get; set; }

        public DbSet<Contact> Customers { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<InventoryType> InventoryTypes { get; set; }

        public DbSet<LotType> LotTypes { get; set; }
    } 
}
