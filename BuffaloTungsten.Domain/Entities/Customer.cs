using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    /// <summary>
    /// This is the customer I found in Matrix Powder Inventory so not sure what else I might need
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(75)]
        public string Name { get; set; }

        public virtual List<Inventory> Inventories { get; set; }
    }
}
