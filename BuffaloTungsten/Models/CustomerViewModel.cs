using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuffaloTungsten.Models
{
    public class CustomerViewModel
    {
        //Contact. Should there be more than one allowed?
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
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
    }
}