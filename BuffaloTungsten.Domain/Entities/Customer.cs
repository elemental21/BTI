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
    /// This is the customer I found in Matrix Powder Inventory so not sure what else I might need
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(10)]
        public string Extension{ get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Notes { get; set; }


        public virtual List<Inventory> Inventories { get; set; }
    }
}
