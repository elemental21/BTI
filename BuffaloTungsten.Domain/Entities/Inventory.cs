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
    /// As of this point I am trying to make all inventories in the same table/class and then 
    /// create a way of querying them
    /// </summary>
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        
        [Index]
        [StringLength(25)]
        public string LotNumber { get; set; }

        // Cycles maybe should be a CyclesStart CyclesEnd although not sure how to key this if we do that. 
        [Index]
        public string Cycles { get; set; }
        
        // This is the differentiator for all three lot types (receiving, production/furnace, finished lot)
        // There is a good chance this might end up being a table too
        [Index]
        [StringLength(10)]
        public string LotType { get; set; }

        [StringLength(25)]
        public string SizeRange { get; set; }

        public DateTime Date { get; set; }

        public int StartBalance { get; set; }

        public int Balance { get; set; }

        //Called For field?  I'm assuming I can get this info from the orders

        public decimal FSSS { get; set; }

        public decimal Scott { get; set; }

        public decimal Total { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        [Index]
        public virtual Product Product { get; set; }

        [Index]
        public virtual Furnace Furnace { get; set; }

        public virtual InventoryType InventoryType { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
