using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuffaloTungsten.Models
{
    public class CustomerIndexViewModel
    {
        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }
        //Contact. Should there be more than one allowed?
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Ext")]
        public string Extention { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Notes")]
        public string Notes { get; set; }
        [Display(Name = "Shipping Address")]
        public CustomerAddress ShippingAddress { get; set; }
        [Display(Name = "Billing Address")]
        public CustomerAddress BillingAddress { get; set; }
        public Boolean? SubmitSuccess { get; set; }
    }

    public class CustomerAddress
    {
        public string Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}