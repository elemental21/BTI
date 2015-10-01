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

        [Index("IX_LotAndCycles", 1)]
        [StringLength(25)]
        public string LotNumber { get; set; }

        [Index("IX_LotAndCycles", 2)]
        public int CycleStart { get; set; }
        [Index("IX_LotAndCycles", 3)]
        public int CycleEnd {get;set;}
        
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

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        [Index]
        public virtual Category Product { get; set; }

        [ForeignKey("Furnace")]
        public int? Furnace_Id { get; set; }
        [Index]
        public virtual Furnace Furnace { get; set; }

        // This is the differentiator for all three lot types (receiving, production/furnace, finished lot)
        [ForeignKey("LotType")]
        public int LotType_Id { get; set; }
        [Index]
        public virtual LotType LotType { get; set; }

        // The Type selector in production inventory 
        [ForeignKey("InventoryType")]
        public int? InventoryType_Id { get; set; }
        public virtual InventoryType InventoryType { get; set; }

        [ForeignKey("Manufacturer")]
        public int? Manufacturer_Id { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("Customer")]
        public int? Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
