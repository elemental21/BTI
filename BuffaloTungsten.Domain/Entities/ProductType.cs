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
    /// These are like categories like W Powder, Crushed Carbide
    /// </summary>

    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
