using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }

        public string PONumber { get; set; }
        //type stuff?  I forget
    }
}
