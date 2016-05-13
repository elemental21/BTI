using BuffaloTungsten.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuffaloTungsten.Models
{
    public class OrderIndexViewModel
    {
        public List<Customer> CustomerList { get; set; }
        public Order Order { get; set; }

        public List<string> ProductType = new List<string>()
        { "Tungsten Powder",
            "Tungsten Carbide Powder"
        };

        [Display(Name = "Select Product Category")]
        [Required]
        public int SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> ProductTypes
        {
            get
            {
                var allProducts = ProductType.Select(f => new SelectListItem
                {
                    Value = f,
                    Text = f
                });
                return allProducts;

            }
        }

        [Display(Name = "Select Customer")]
        [Required]
        public int SelectedCustomerId { get; set; }
        public IEnumerable<SelectListItem> Customers
        {
            get
            {
                var allCust = CustomerList.Select(f => new SelectListItem
                    {
                        Value = f.Id.ToString(),
                        Text = f.CompanyName
                    });

                return allCust;
            }
        }
    }
}