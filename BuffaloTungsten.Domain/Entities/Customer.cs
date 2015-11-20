using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        //[ForeignKey("PrimaryContact")]
        //public int? Contact_Id { get; set; }
        //public virtual Contact PrimaryContact { get; set; }

        [ForeignKey("ShippingAddress")]
        public int? ShippingAddress_Id { get; set; }
        // Can create 1-1 table if more addresses necessary
        public virtual Address ShippingAddress { get; set; }

        [ForeignKey("BillingAddress")]
        public int? BillingAddress_Id { get; set; }
        // Can create 1-1 table if more addresses necessary
        public virtual Address BillingAddress { get; set; }

        //Add customer specifications

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual List<Inventory> Inventories { get; set; }
    }
}
