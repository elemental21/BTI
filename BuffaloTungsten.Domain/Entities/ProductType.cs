using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Entities
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
