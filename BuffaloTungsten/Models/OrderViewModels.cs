using BuffaloTungsten.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuffaloTungsten.Models
{
    public class OrderIndexViewModel
    {
        public List<Customer> CustomerList { get; set; }
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