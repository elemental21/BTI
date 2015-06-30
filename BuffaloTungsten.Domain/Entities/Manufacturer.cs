using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    /// <summary>
    /// This is the manufacturer I found in Misc Powder Inventory so not sure what else I'll need here 6/29/2015
    /// </summary>
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(75)]
        public string Name { get; set; }

        public virtual Inventory Inventories { get; set; }
    }
}
