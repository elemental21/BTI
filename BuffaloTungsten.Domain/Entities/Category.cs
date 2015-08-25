using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Parent_Id { get; set; }

        [ForeignKey("Parent_Id")]
        public virtual Category Parent { get; set; }

        //public virtual List<Category> Children { get; set; }

        public virtual List<Inventory> Inventories { get; set; }

        // This is the differentiator for all three lot types (receiving, production/furnace, finished lot)
        // Here it is used because all the inventory inside each product is always one of the three types
        [Index]
        public virtual LotType LotType { get; set; }
    }
}
