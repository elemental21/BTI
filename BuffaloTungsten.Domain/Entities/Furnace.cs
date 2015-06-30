using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    public class Furnace
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Inventory> Inventories { get; set; }
    }
}
