using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ProductType ProductType { get; set; }

        public virtual List<Inventory> Inventory { get; set; }
    }
}
