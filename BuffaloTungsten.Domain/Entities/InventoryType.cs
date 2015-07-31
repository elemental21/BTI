using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    /// <summary>
    /// This is a furnace run type for use in inventory values W/Rerun/Toll
    /// </summary>
    public class InventoryType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }
    }
}
