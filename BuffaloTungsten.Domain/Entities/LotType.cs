using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    /// <summary>
    /// This is the differentiator for all three lot types (receiving, production/furnace, finished lot)
    /// This is used on all 
    /// </summary>
    public class LotType
    {
        [Key]
        public int Id { get; set; }

        [Index]
        [StringLength(10)]
        public string Name { get; set; }

        public virtual List<Inventory> Inventories { get; set; }

        public virtual List<Category> ProductCategories { get; set; }
    }
}
